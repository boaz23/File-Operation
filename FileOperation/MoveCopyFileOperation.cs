using System.Diagnostics;

using Utility.IO;

namespace FileOperation
{
    public abstract class MoveCopyFileOperation : FileOperationItem
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string sourceFilePath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string destionationFolderPath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string fileName;

        public MoveCopyFileOperation() { }
        public MoveCopyFileOperation(string sourceFilePath, string destionationFolderPath)
        {
            this.SourceFilePath = sourceFilePath;
            this.DestionationFolderPath = destionationFolderPath;
        }
        public MoveCopyFileOperation
        (
            string sourceFilePath,
            string destionationFolderPath,
            string fileName
        )
        {
            this.SourceFilePath = sourceFilePath;
            this.DestionationFolderPath = destionationFolderPath;
            this.FileName = fileName;
        }

        public string SourceFilePath
        {
            get
            {
                return this.sourceFilePath;
            }
            set
            {
                FileSystem.CheckPathArgument(value, nameof(value));
                this.sourceFilePath = value;
            }
        }
        public string DestionationFolderPath
        {
            get
            {
                return this.destionationFolderPath;
            }
            set
            {
                FileSystem.CheckPathArgument(value, nameof(value));
                this.destionationFolderPath = value;
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
                FileSystem.CheckFileNameArgumentAllowNull(value, nameof(value));
                this.fileName = value;
            }
        }
    }
}