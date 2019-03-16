using System;

namespace FileOperation
{
    public class PreNewEventArgs : EventArgs
    {
        public PreNewEventArgs
        (
            TransferSourceFlags transferSourceFlags,
            string filePath,
            string fileName
        )
        {
            this.TransferSourceFlags = transferSourceFlags;
            this.FilePath = filePath;
            this.FileName = fileName;
        }

        public TransferSourceFlags TransferSourceFlags { get; }
        public string FilePath { get; }
        public string FileName { get; }
    }
}