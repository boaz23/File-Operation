using System.IO;

namespace FileOperation
{
    public class PostNewEventArgs : FinishOperaionsEventArgs
    {
        public PostNewEventArgs
        (
            TransferSourceFlags transferSourceFlags,
            string destinationFolderPath,
            string fileName,
            string templateName,
            FileAttributes fileAttributes,
            string filePath,
            int hrResult
        ) : base(hrResult)
        {
            this.TransferSourceFlags = transferSourceFlags;
            this.DestinationFolderPath = destinationFolderPath;
            this.FileName = fileName;
            this.TemplateName = templateName;
            this.FileAttributes = fileAttributes;
            this.FilePath = filePath;
        }

        public TransferSourceFlags TransferSourceFlags { get; }
        public string DestinationFolderPath { get; }
        public string FileName { get; }
        public string TemplateName { get; }
        public FileAttributes FileAttributes { get; }
        public string FilePath { get; }
    }
}