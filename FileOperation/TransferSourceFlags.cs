using System;
using FileOperation.Native.Types;

namespace FileOperation
{
    [Flags]
    public enum TransferSourceFlags
    {
        Noraml = TSF.NORMAL,
        FailAlreadyExists = TSF.FAIL_EXIST,
        RenameIfExists = TSF.RENAME_EXIST,
        OverwriteIfExsists = TSF.OVERWRITE_EXIST,
        AllowDecryption = TSF.ALLOW_DECRYPTION,
        NoSecurity = TSF.NO_SECURITY,
        CopyCreationTime = TSF.COPY_CREATION_TIME,
        CopyWriteTime = TSF.COPY_WRITE_TIME,
        FullAccess = TSF.USE_FULL_ACCESS,
        RecycleDelteIfPossible = TSF.DELETE_RECYCLE_IF_POSSIBLE,
        CopyHardLink = TSF.COPY_HARD_LINK,
        CopyLocalizedName = TSF.COPY_LOCALIZED_NAME,
        MoveAsCopyDelete = TSF.MOVE_AS_COPY_DELETE,
        SuspendShellEvents = TSF.SUSPEND_SHELLEVENTS
    }
}