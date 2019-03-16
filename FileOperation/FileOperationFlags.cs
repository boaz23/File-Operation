using System;

using FileOperation.Native.Types;

namespace FileOperation
{
    [Flags]
    public enum FileOperationFlags
    {
        None = 0,
        NoConfirmation = FOF.NOCONFIRMATION,
        [Obsolete("Use '" + nameof(AllowUndoEx) + "' instead.")]
        AllowUndo = FOF.ALLOWUNDO,
        FilesOnly = FOF.FILESONLY,
        NoConfirmDirectoryCreation = FOF.NOCONFIRMMKDIR,
        NoCopySecurityAttributes = FOF.NOCOPYSECURITYATTRIBS,
        NoConnectedElements = FOF.NO_CONNECTED_ELEMENTS,
        NoFolderRecursion = FOF.NORECURSION,
        RenameFileOnCollision = FOF.RENAMEONCOLLISION,
        IgnoreErrors = FOF.NOERRORUI,
        AbortAllOnError = FOFX.EARLYFAILURE,
        NoProgressDialog = FOF.SILENT,
        PermanentDeleteWarning = FOF.WANTNUKEWARNING,
        AllowUndoEx = FOFX.ADDUNDORECORD,
        NoSkipJunctions = FOFX.NOSKIPJUNCTIONS,
        PreferHardLink = FOFX.PREFERHARDLINK,
        ShowElevatedPermissionsPrompt = FOFX.SHOWELEVATIONPROMPT,
        PreserveFileExtensionOnCollisionRename = FOFX.PRESERVEFILEEXTENSIONS,
        KeepNewerFile = FOFX.KEEPNEWERFILE,
        NoCopyHooks = FOFX.NOCOPYHOOKS,
        NoMinimizeDialog = FOFX.NOMINIMIZEBOX,
        CopySecurityAttributesAcrossVolumes = FOFX.MOVEACLSACROSSVOLUMES,
        NoDisplaySoucePath = FOFX.DONTDISPLAYSOURCEPATH,
        NoDisplayDestinationPath = FOFX.DONTDISPLAYDESTPATH,
        RecycleOnDelete = FOFX.RECYCLEONDELETE,
        RequireElevatedPermissions = FOFX.REQUIREELEVATION,
        DisplayCopyAsDownload = FOFX.COPYASDOWNLOAD,
        NoDisplayLocation = FOFX.DONTDISPLAYLOCATIONS
    }
}