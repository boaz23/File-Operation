using System.Diagnostics;

using static Utility.Strings;

namespace FileOperation
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class CopyFileOperation : MoveCopyFileOperation
    {
        public CopyFileOperation() : base() { }
        public CopyFileOperation(string sourceFilePath, string destionationFolderPath) :
            base(sourceFilePath, destionationFolderPath) { }
        public CopyFileOperation
        (
            string sourceFilePath,
            string destionationFolderPath,
            string fileName
        ) : base(sourceFilePath, destionationFolderPath, fileName) { }

        internal override void AddToFileOperationQueue(FileOperation fileOperation)
        {
            fileOperation.AddCopyFileOperation(this);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
        {
            get
            {
                string s = $"🗇\"{this.SourceFilePath}\" --> 🗇\"{this.DestionationFolderPath}";
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