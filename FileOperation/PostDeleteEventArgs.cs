namespace FileOperation
{
    public class PostDeleteEventArgs : FinishOperaionsEventArgs
    {
        public PostDeleteEventArgs
        (
            TransferSourceFlags transferSourceFlags,
            string deletedFilePath,
            string recycleBinFilePath,
            int hrRename
        ) : base(hrRename)
        {
            this.TransferSourceFlags = transferSourceFlags;
            this.DeletedFilePath = deletedFilePath;
            this.RecycleBinFilePath = recycleBinFilePath;
        }

        public TransferSourceFlags TransferSourceFlags { get; }
        public string DeletedFilePath { get; }
        public string RecycleBinFilePath { get; }
    }
}