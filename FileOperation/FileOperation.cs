using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

using FileOperation.Native.Types;

using Utility;
using Utility.Collections.Generic;
using Utility.Interop;
using Utility.Interop.Native;
using Utility.Interop.Native.Types;
using Utility.IO;

namespace FileOperation
{
    public partial class FileOperation : Disposable, IFileOperation
    {
        private delegate void AddMoveCopyOperationAction
        (
            IShellItem file,
            IShellItem destFolder,
            string fileName,
            IFileOperationProgressSink operationSink
        );

        private static readonly IFileSystemBindData CreateFolderIfDoesntExistsFileSystemBindData;

        private Native.Types.FileOperation fileOperation;
        private int cookie;

        static FileOperation()
        {
            CreateFolderIfDoesntExistsFileSystemBindData = new FileSystemBindData(new WIN32_FIND_DATA
            {
                dwFileAttributes = FILE_ATTRIBUTE.DIRECTORY
            });
        }

        public FileOperation()
        {
            this.FileOperations = new List<FileOperationItem>();

            this.fileOperation = new Native.Types.FileOperation();
            this.cookie = this.fileOperation.Advise(new FileOperationProgressSink(this));
        }

        public FileOperation(IntPtr ownerWindowHandle)
        {
            this.OwnerWindowHandle = ownerWindowHandle;
            this.FileOperations = new List<FileOperationItem>();

            this.fileOperation = new Native.Types.FileOperation();
            this.fileOperation.SetOwnerWindow(ownerWindowHandle);
            this.cookie = this.fileOperation.Advise(new FileOperationProgressSink(this));
        }

        public IntPtr OwnerWindowHandle { get; }
        public FileOperationFlags OperationsFlags { get; set; }
        public List<FileOperationItem> FileOperations { get; }
        IList<FileOperationItem> IFileOperation.FileOperations => FileOperations;

        public event EventHandler<EventArgs> OnOperationsStart;
        public event EventHandler<FinishOperaionsEventArgs> OnOperationsFinish;
        public event EventHandler<PreRenameEventArgs> OnPreRename;
        public event EventHandler<PostRenameEventArgs> OnPostRename;
        public event EventHandler<PreMoveCopyEventArgs> OnPreMove;
        public event EventHandler<PostMoveCopyEventArgs> OnPostMove;
        public event EventHandler<PreMoveCopyEventArgs> OnPreCopy;
        public event EventHandler<PostMoveCopyEventArgs> OnPostCopy;
        public event EventHandler<PreDeleteEventArgs> OnPreDelete;
        public event EventHandler<PostDeleteEventArgs> OnPostDelete;
        public event EventHandler<PreNewEventArgs> OnPreNew;
        public event EventHandler<PostNewEventArgs> OnPostNew;

        public bool GetAnyOperationsAborted()
        {
            return this.fileOperation.GetAnyOperationsAborted();
        }

        public void AddOperation(FileOperationItem operation)
        {
            this.FileOperations.Add(operation);
        }

        public void ClearAllOperations()
        {
            this.FileOperations.Clear();
        }

        public void PerformOperations()
        {
            this.ThorwIfDisposed();

            this.fileOperation.SetOperationFlags((int)this.OperationsFlags);
            this.QueueFileOperations(this.FileOperations);
            this.fileOperation.PerformOperations();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.fileOperation.Unadvise(this.cookie);
                _ = Marshal.ReleaseComObject(this.fileOperation);
                this.fileOperation = null;
            }
        }

        private void QueueFileOperations<TOperation>(IList<TOperation> operations)
            where TOperation : FileOperationItem
        {
            for (int i = 0, count = operations.Count; i < count; i++)
            {
#if DEBUG
                TOperation operation = operations[i];
                operation.AddToFileOperationQueue(this);
#else
                operations[i].AddToFileOperationQueue(this);
#endif
            }
        }

        internal void AddRenameFileOperation(RenameFileOperation renameFileOperation)
        {
            using (var file = new ComReleaser<IShellItem>(CreateShellItem(renameFileOperation.FilePath)))
            {
                this.fileOperation.RenameItem(file.ComObject, renameFileOperation.NewFileName, null);
            }
        }

        internal void AddMoveFileOperation(MoveFileOperation moveFileOperation)
        {
            AddMoveCopyItem(moveFileOperation, this.fileOperation.MoveItem);
        }

        internal void AddCopyFileOperation(CopyFileOperation copyFileOperation)
        {
            AddMoveCopyItem(copyFileOperation, this.fileOperation.CopyItem);
        }

        internal void AddDeleteFileOperation(DeleteFileOperation deleteFileOperation)
        {
            using (var file = new ComReleaser<IShellItem>(CreateShellItem(deleteFileOperation.FilePath)))
            {
                this.fileOperation.DeleteItem(file.ComObject, null);
            }
        }

        internal void AddNewFileOperation(NewFileOperation newFileOperation)
        {
            using (var destFolder = new ComReleaser<IShellItem>(CreateFolderShellItem(newFileOperation.DestinationFolderPath)))
            {
                this.fileOperation.NewItem
                (
                    destFolder.ComObject,
                    (FILE_ATTRIBUTE)newFileOperation.FileAttributes,
                    newFileOperation.FileName,
                    newFileOperation.TemplateName,
                    null
                );
            }
        }

        private void AddMoveCopyItem
        (
            MoveCopyFileOperation moveCopyFileOperation,
            AddMoveCopyOperationAction addMoveCopyOperationAction
        )
        {
            using (var sourceFile = new ComReleaser<IShellItem>(CreateShellItem(moveCopyFileOperation.SourceFilePath)))
            using (var destFolder = new ComReleaser<IShellItem>(CreateFolderShellItem(moveCopyFileOperation.DestionationFolderPath)))
            {
                addMoveCopyOperationAction
                (
                    sourceFile.ComObject,
                    destFolder.ComObject,
                    moveCopyFileOperation.FileName,
                    null
                );
            }
        }

        private static IShellItem CreateFolderShellItem(string path)
        {
            IShellItem shellItem;
            path = Path.GetFullPath(path);
            if (FileSystem.DoesPathExist(path))
            {
                shellItem = CreateShellItem(path);
            }
            else
            {
                using (var bindCtxReleaser = new ComReleaser<IBindCtx>(NativeMethods.CreateBindCtx()))
                {
                    IBindCtx bindCtx = bindCtxReleaser.ComObject;
                    bindCtx.RegisterObjectParam
                    (
                        NativeMethods.STR_FILE_SYS_BIND_DATA,
                        CreateFolderIfDoesntExistsFileSystemBindData
                    );

                    shellItem = CreateShellItem(path, bindCtx);
                }
            }

            return shellItem;
        }

        private static IShellItem CreateShellItem(string path)
        {
            return CreateShellItem(path, null);
        }
        private static IShellItem CreateShellItem(string path, IBindCtx bindCtx)
        {
            Guid riid = typeof(IShellItem).GUID;
            path = Path.GetFullPath(path);
            return NativeMethods.SHCreateItemFromParsingName
            (
                path,
                bindCtx,
                ref riid
            );
        }
    }
}