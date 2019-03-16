using System;
using System.IO;

using FileOperation.Native.Types;

using Utility.Interop.Native.Types;

namespace FileOperation
{
    public partial class FileOperation
    {
        private class FileOperationProgressSink : IFileOperationProgressSink
        {
            private readonly FileOperation fileOperation;

            public FileOperationProgressSink(FileOperation fileOperation)
            {
                this.fileOperation = fileOperation;
            }

            public virtual void StartOperations()
            {
                this.fileOperation.OnOperationsStart?.Invoke(this.fileOperation, EventArgs.Empty);
            }

            public virtual void FinishOperations(int hrResult)
            {
                this.fileOperation.OnOperationsFinish?.Invoke
                (
                    this.fileOperation,
                    new FinishOperaionsEventArgs(hrResult)
                );
            }

            public virtual void PreRenameItem(TSF dwFlags, IShellItem psiItem, string pszNewName)
            {
                this.fileOperation.OnPreRename?.Invoke
                (
                    this.fileOperation,
                    new PreRenameEventArgs
                    (
                        (TransferSourceFlags)dwFlags,
                        psiItem.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        pszNewName
                    )
                );
            }

            public virtual void PostRenameItem
            (
                TSF dwFlags,
                IShellItem psiItem,
                string pszNewName,
                int hrRename,
                IShellItem psiNewlyCreated
            )
            {
                this.fileOperation.OnPostRename?.Invoke
                (
                    this.fileOperation,
                    new PostRenameEventArgs
                    (
                        (TransferSourceFlags)dwFlags,
                        psiItem.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        pszNewName,
                        psiNewlyCreated.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        psiNewlyCreated.GetDisplayName(SIGDN.PARENTRELATIVE),
                        hrRename
                    )
                );
            }

            public virtual void PreMoveItem
            (
                TSF dwFlags,
                IShellItem psiItem,
                IShellItem psiDestinationFolder,
                string pszNewName
            )
            {
                this.fileOperation.OnPreMove?.Invoke
                (
                    this.fileOperation,
                    new PreMoveCopyEventArgs
                    (
                        (TransferSourceFlags)dwFlags,
                        psiItem.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        psiDestinationFolder.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        pszNewName
                    )
                );
            }

            public virtual void PostMoveItem
            (
                TSF dwFlags,
                IShellItem psiItem,
                IShellItem psiDestinationFolder,
                string pszNewName,
                int hrMove,
                IShellItem psiNewlyCreated
            )
            {
                this.fileOperation.OnPostMove?.Invoke
                (
                    this.fileOperation,
                    new PostMoveCopyEventArgs
                    (
                        (TransferSourceFlags)dwFlags,
                        psiItem.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        psiDestinationFolder.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        psiNewlyCreated.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        pszNewName,
                        hrMove
                    )
                );
            }

            public virtual void PreCopyItem
            (
                TSF dwFlags,
                IShellItem psiItem,
                IShellItem psiDestinationFolder,
                string pszNewName
            )
            {
                this.fileOperation.OnPreCopy?.Invoke
                (
                    this.fileOperation,
                    new PreMoveCopyEventArgs
                    (
                        (TransferSourceFlags)dwFlags,
                        psiItem.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        psiDestinationFolder.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        pszNewName
                    )
                );
            }

            public virtual void PostCopyItem
            (
                TSF dwFlags,
                IShellItem psiItem,
                IShellItem psiDestinationFolder,
                string pszNewName,
                int hrCopy,
                IShellItem psiNewlyCreated
            )
            {
                this.fileOperation.OnPostCopy?.Invoke
                (
                    this.fileOperation,
                    new PostMoveCopyEventArgs
                    (
                        (TransferSourceFlags)dwFlags,
                        psiItem.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        psiDestinationFolder.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        psiNewlyCreated.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        pszNewName,
                        hrCopy
                    )
                );
            }

            public virtual void PreDeleteItem(TSF dwFlags, IShellItem psiItem)
            {
                this.fileOperation.OnPreDelete?.Invoke
                (
                    this.fileOperation,
                    new PreDeleteEventArgs
                    (
                        (TransferSourceFlags)dwFlags,
                        psiItem.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING)
                    )
                );
            }

            public virtual void PostDeleteItem
            (
                TSF dwFlags,
                IShellItem psiItem,
                int hrDelete,
                IShellItem psiNewlyCreated
            )
            {
                this.fileOperation.OnPostDelete?.Invoke
                (
                    this.fileOperation,
                    new PostDeleteEventArgs
                    (
                        (TransferSourceFlags)dwFlags,
                        psiItem.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        psiNewlyCreated?.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        hrDelete
                    )
                );
            }

            public virtual void PreNewItem
            (
                TSF dwFlags,
                IShellItem psiItem,
                string pszNewName
            )
            {
                this.fileOperation.OnPreNew?.Invoke
                (
                    this.fileOperation,
                    new PreNewEventArgs
                    (
                        (TransferSourceFlags)dwFlags,
                        psiItem.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        pszNewName
                    )
                );
            }

            public virtual void PostNewItem
            (
                TSF dwFlags,
                IShellItem psiDestinationFolder,
                string pszNewName,
                string pszTemplateName,
                FILE_ATTRIBUTE dwFileAttributes,
                int hrNew,
                IShellItem psiNewItem
            )
            {
                this.fileOperation.OnPostNew?.Invoke
                (
                    this.fileOperation,
                    new PostNewEventArgs
                    (
                        (TransferSourceFlags)dwFlags,
                        psiDestinationFolder.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        pszNewName,
                        pszTemplateName,
                        (FileAttributes)dwFileAttributes,
                        psiNewItem.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING),
                        hrNew
                    )
                );
            }

            public virtual void UpdateProgress(int iWorkTotal, int iWorkSoFar)
            {
            }

            public virtual void ResetTimer()
            {
            }

            public virtual void PauseTimer()
            {
            }

            public virtual void ResumeTimer()
            {
            }
        }
    }
}