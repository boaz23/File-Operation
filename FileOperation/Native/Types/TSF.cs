using System;
using Utility.Interop;

namespace FileOperation.Native.Types
{
    [Flags]
    [UnmanagedDefinition("TRANSFER_SOURCE_FLAGS")]
    public enum TSF : int
    {
        NORMAL                     = 0,
        FAIL_EXIST                 = 0,
        RENAME_EXIST               = 0x1,
        OVERWRITE_EXIST            = 0x2,
        ALLOW_DECRYPTION           = 0x4,
        NO_SECURITY                = 0x8,
        COPY_CREATION_TIME         = 0x10,
        COPY_WRITE_TIME            = 0x20,
        USE_FULL_ACCESS            = 0x40,
        DELETE_RECYCLE_IF_POSSIBLE = 0x80,
        COPY_HARD_LINK             = 0x100,
        COPY_LOCALIZED_NAME        = 0x200,
        MOVE_AS_COPY_DELETE        = 0x400,
        SUSPEND_SHELLEVENTS        = 0x800
    }
}