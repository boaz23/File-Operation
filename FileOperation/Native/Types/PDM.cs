﻿using Utility.Interop;

namespace FileOperation.Native.Types
{
    [UnmanagedDefinition("PDMODE")]
    public enum PDM : int
    {
        DEFAULT        = 0x00000000,
        RUN            = 0x00000001,
        PREFLIGHT      = 0x00000002,
        UNDOING        = 0x00000004,
        ERRORSBLOCKING = 0x00000008,
        INDETERMINATE  = 0x00000010
    }
}