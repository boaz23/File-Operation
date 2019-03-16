using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Utility.Interop.Native.Types;

namespace FileOperation.Native.Types
{
    [ComImport]
    [Guid(IID.IFileOperationProgressSink)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileOperationProgressSink
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void StartOperations();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void FinishOperations([In] int hrResult);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PreRenameItem
        (
            [In] TSF dwFlags,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszNewName
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PostRenameItem
        (
            [In] TSF dwFlags,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
            [In] [MarshalAs(UnmanagedType.Error)] int hrRename,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiNewlyCreated
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PreMoveItem
        (
            [In] TSF dwFlags,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiDestinationFolder,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszNewName
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PostMoveItem
        (
            [In] TSF dwFlags,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiDestinationFolder,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
            [In] [MarshalAs(UnmanagedType.Error)] int hrMove,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiNewlyCreated
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PreCopyItem
        (
            [In] TSF dwFlags,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiDestinationFolder,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszNewName
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PostCopyItem
        (
            [In] TSF dwFlags,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiDestinationFolder,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
            [In] [MarshalAs(UnmanagedType.Error)] int hrCopy,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiNewlyCreated
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PreDeleteItem
        (
            [In] TSF dwFlags,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PostDeleteItem
        (
            [In] TSF dwFlags,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem,
            [In] [MarshalAs(UnmanagedType.Error)] int hrDelete,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiNewlyCreated
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PreNewItem
        (
            [In] TSF dwFlags,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszNewName
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PostNewItem
        (
            [In] TSF dwFlags,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiDestinationFolder,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszTemplateName,
            [In] FILE_ATTRIBUTE dwFileAttributes,
            [In] [MarshalAs(UnmanagedType.Error)] int hrNew,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiNewItem
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UpdateProgress([In] int iWorkTotal, [In] int iWorkSoFar);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ResetTimer();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PauseTimer();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ResumeTimer();
    }
}