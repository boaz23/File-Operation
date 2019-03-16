using System.Diagnostics;

using Utility.IO;

namespace FileOperation
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class RenameFileOperation : FileOperationItem
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string filePath;

        public RenameFileOperation() { }
        public RenameFileOperation(string filePath, string newFileName)
        {
            this.FilePath = filePath;
            this.NewFileName = newFileName;
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
        public string NewFileName { get; set; }

        internal override void AddToFileOperationQueue(FileOperation fileOperation)
        {
            fileOperation.AddRenameFileOperation(this);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
        {
            get
            {
                return $"\"{this.FilePath}\" 🖉--> \"{this.NewFileName}\"";
            }
        }
    }
}