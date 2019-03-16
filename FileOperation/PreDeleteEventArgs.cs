using System;

namespace FileOperation
{
    public class PreDeleteEventArgs : EventArgs
    {
        public PreDeleteEventArgs
        (
            TransferSourceFlags transferSourceFlags,
            string filePath
        )
        {
            this.TransferSourceFlags = transferSourceFlags;
            this.FilePath = filePath;
        }

        public TransferSourceFlags TransferSourceFlags { get; }
        public string FilePath { get; }
    }
}