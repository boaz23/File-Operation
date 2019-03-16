using System.Diagnostics;

using Utility.IO;

namespace FileOperation
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class DeleteFileOperation : FileOperationItem
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string filePath;

        public DeleteFileOperation() { }
        public DeleteFileOperation(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath
        {
            get
            {
                return this.filePath;
            }
            set
            {
                FileSystem.CheckPathArgument(value, nameof(value));
                this.filePath = value;
            }
        }

        internal override void AddToFileOperationQueue(FileOperation fileOperation)
        {
            fileOperation.AddDeleteFileOperation(this);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
        {
            get
            {
                return $"🗑 \"{this.FilePath}\"";
            }
        }
    }
}