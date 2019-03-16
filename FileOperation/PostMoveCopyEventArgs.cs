namespace FileOperation
{
    public class PostMoveCopyEventArgs : FinishOperaionsEventArgs
    {
        public PostMoveCopyEventArgs
        (
            TransferSourceFlags transferSourceFlags,
            string sourceFilePath,
            string destinationFolderPath,
            string destinationFilePath,
            string destinationFileName,
            int hrResult
        ) : base(hrResult)
        {
            this.TransferSourceFlags = transferSourceFlags;
            this.SourceFilePath = sourceFilePath;
            this.DestinationFolderPath = destinationFolderPath;
            this.DestionationFilePath = destinationFilePath;
            this.DestionationFileName = destinationFileName;
        }

        public TransferSourceFlags TransferSourceFlags { get; }
        public string SourceFilePath { get; }
        public string DestinationFolderPath { get; }
        public string DestionationFilePath { get; }
        public string DestionationFileName { get; }
    }
}