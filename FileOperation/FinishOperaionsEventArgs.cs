using System;

using Utility.Interop.Native;

namespace FileOperation
{
    public class FinishOperaionsEventArgs : EventArgs
    {
        private readonly HRESULT hrResult;

        public FinishOperaionsEventArgs(int hrResult)
        {
            this.hrResult = hrResult;
        }

        public int HrResult => this.hrResult;
        public bool IsSuccess => this.hrResult.IsSuccess;
    }
}