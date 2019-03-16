namespace FileOperation
{
    public class PostRenameEventArgs : FinishOperaionsEventArgs
    {
        public PostRenameEventArgs
        (
            TransferSourceFlags transferSourceFlags,
            string renamedFilePath,
            string expectedNewFileName,
            string newFilePath,
            string newFileName,
            int hrRename
        ) : base(hrRename)
        {
            this.TransferSourceFlags = transferSourceFlags;
            this.RenamedFilePath = renamedFilePath;
            this.ExpectedNewFileName = expectedNewFileName;
            this.NewFilePath = newFilePath;
            this.NewFileName = newFileName;
        }

        public TransferSourceFlags TransferSourceFlags { get; }
        public string RenamedFilePath { get; }
        public string ExpectedNewFileName { get; }
        public string NewFilePath { get; }
        public string NewFileName { get; }
    }
}