using System;

namespace FileOperation
{
    public class PreRenameEventArgs : EventArgs
    {
        public PreRenameEventArgs
        (
            TransferSourceFlags transferSourceFlags,
            string filePath,
            string newFileName
        )
        {
            this.TransferSourceFlags = transferSourceFlags;
            this.FilePath = filePath;
            this.NewFileName = newFileName;
        }

        public TransferSourceFlags TransferSourceFlags { get; }
        public string FilePath { get; }
        public string NewFileName { get; }
    }
}