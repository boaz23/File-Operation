using System;
using System.Collections.Generic;

namespace FileOperation
{
    public interface IFileOperation
    {
        IntPtr OwnerWindowHandle { get; }
        FileOperationFlags OperationsFlags { get; set; }
        IList<FileOperationItem> FileOperations { get; }

        event EventHandler<FinishOperaionsEventArgs> OnOperationsFinish;
        event EventHandler<EventArgs> OnOperationsStart;
        event EventHandler<PostMoveCopyEventArgs> OnPostCopy;
        event EventHandler<PostDeleteEventArgs> OnPostDelete;
        event EventHandler<PostMoveCopyEventArgs> OnPostMove;
        event EventHandler<PostNewEventArgs> OnPostNew;
        event EventHandler<PostRenameEventArgs> OnPostRename;
        event EventHandler<PreMoveCopyEventArgs> OnPreCopy;
        event EventHandler<PreDeleteEventArgs> OnPreDelete;
        event EventHandler<PreMoveCopyEventArgs> OnPreMove;
        event EventHandler<PreNewEventArgs> OnPreNew;
        event EventHandler<PreRenameEventArgs> OnPreRename;

        void AddOperation(FileOperationItem operation);
        void ClearAllOperations();
        bool GetAnyOperationsAborted();
        void PerformOperations();
    }
}