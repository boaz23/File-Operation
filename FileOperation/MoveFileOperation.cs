using System.Diagnostics;

using static Utility.Strings;

namespace FileOperation
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class MoveFileOperation : MoveCopyFileOperation
    {
        public MoveFileOperation() : base() { }
        public MoveFileOperation(string sourceFilePath, string destionationFolderPath) :
            base(sourceFilePath, destionationFolderPath) { }
        public MoveFileOperation
        (
            string sourceFilePath,
            string destionationFolderPath,
            string fileName
        ) : base(sourceFilePath, destionationFolderPath, fileName) { }

        internal override void AddToFileOperationQueue(FileOperation fileOperation)
        {
            fileOperation.AddMoveFileOperation(this);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
        {
            get
            {
                string s = $"🗋\"{this.SourceFilePath}\" ✀--> \"{this.DestionationFolderPath}";
                if (!this.FileName.IsNullOrWhiteSpace())
                {
                    s += $@"\{this.FileName}";
                }
                s += "\"";

                return s;
            }
        }
    }
}