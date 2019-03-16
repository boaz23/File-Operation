using System;

namespace FileOperation
{
    public class PreMoveCopyEventArgs : EventArgs
    {
        public PreMoveCopyEventArgs
        (
            TransferSourceFlags transferSourceFlags,
            string filePath,
            string destinationFolderPath,
            string newFileName
        )
        {
            this.TransferSourceFlags = transferSourceFlags;
            this.FilePath = filePath;
            this.DestinationFolderPath = destinationFolderPath;
            this.DestinationFileName = newFileName;
        }

        public TransferSourceFlags TransferSourceFlags { get; }
        public string FilePath { get; }
        public string DestinationFolderPath { get; }
        public string DestinationFileName { get; }
    }
}