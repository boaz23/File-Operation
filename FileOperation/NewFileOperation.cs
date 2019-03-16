using System.Diagnostics;
using System.IO;

using Utility.IO;

namespace FileOperation
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class NewFileOperation : FileOperationItem
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string destinationFolderPath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string fileName;

        public NewFileOperation() { }
        public NewFileOperation
        (
            string destinationFolderPath,
            string fileName,
            string templateName,
            FileAttributes fileAttributes
        )
        {
            this.DestinationFolderPath = destinationFolderPath;
            this.FileName = fileName;
            this.TemplateName = templateName;
            this.FileAttributes = fileAttributes;
        }

        public string DestinationFolderPath
        {
            get
            {
                return this.destinationFolderPath;
            }
            set
            {
                FileSystem.CheckPathArgument(value, nameof(value));
                this.destinationFolderPath = value;
            }
        }
        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                FileSystem.CheckFileNameArgument(value, nameof(value));
                this.fileName = value;
            }
        }
        public string TemplateName { get; set; }
        public FileAttributes FileAttributes { get; set; }

        internal override void AddToFileOperationQueue(FileOperation fileOperation)
        {
            fileOperation.AddNewFileOperation(this);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
        {
            get
            {
                return $"🗋 \"{this.DestinationFolderPath}\\{this.FileName}\"";
            }
        }
    }
}