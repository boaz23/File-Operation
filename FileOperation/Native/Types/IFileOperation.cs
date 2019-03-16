using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Utility;
using Utility.Interop;
using Utility.Interop.Native.Types;

namespace FileOperation.Native.Types
{
    [ComImport]
    [Guid(IID.IFileOperation)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileOperation
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: UnmanagedDefinition("DWORD *pdwCookie")]
        int Advise([In] [MarshalAs(UnmanagedType.Interface)] IFileOperationProgressSink pfops);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Unadvise([In] int dwCookie);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetOperationFlags
        (
            [In]
            [PossibleTypes(typeof(FOF), typeof(FOFX))]
            int dwOperationFlags
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetProgressMessage([In] [MarshalAs(UnmanagedType.LPWStr)] string pszMessage);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetProgressDialog([In] [MarshalAs(UnmanagedType.Interface)] IOperationsProgressDialog popd);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetProperties([In] [MarshalAs(UnmanagedType.Interface)] IPropertyChangeArray pproparray);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetOwnerWindow([In] IntPtr hwndOwner);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ApplyPropertiesToItem([In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ApplyPropertiesToItems([In] [MarshalAs(UnmanagedType.IUnknown)] object punkItems);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RenameItem
        (
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
            [In] [MarshalAs(UnmanagedType.Interface)] IFileOperationProgressSink pfopsItem
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RenameItems
        (
            [In] [MarshalAs(UnmanagedType.IUnknown)] object punkItems,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszNewName
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void MoveItem
        (
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiDestinationFolder,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
            [In] [MarshalAs(UnmanagedType.Interface)] IFileOperationProgressSink pfopsItem
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void MoveItems
        (
            [In] [MarshalAs(UnmanagedType.IUnknown)] object punkItems,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiDestinationFolder
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CopyItem
        (
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiDestinationFolder,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszCopyName,
            [In] [MarshalAs(UnmanagedType.Interface)] IFileOperationProgressSink pfopsItem
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CopyItems
        (
            [In] [MarshalAs(UnmanagedType.IUnknown)] object punkItems,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiDestinationFolder
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DeleteItem
        (
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem,
            [In] [MarshalAs(UnmanagedType.Interface)] IFileOperationProgressSink pfopsItem
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DeleteItems([In] [MarshalAs(UnmanagedType.IUnknown)] object punkItems);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewItem
        (
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiDestinationFolder,
            [In] FILE_ATTRIBUTE dwFileAttributes,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszTemplateName,
            [In] [MarshalAs(UnmanagedType.Interface)] IFileOperationProgressSink pfopsItem
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PerformOperations();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [return: UnmanagedDefinition("BOOL *pfAnyOperationsAborted")]
        bool GetAnyOperationsAborted();
    }

    [ComImport]
    [Guid(IID.IFileOperation)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [CoClass(typeof(FileOperationClass))]
#pragma warning disable IDE1006 // Naming Styles
    public interface FileOperation : IFileOperation
#pragma warning restore IDE1006 // Naming Styles
    {
    }

    [ComImport]
    [Guid(CLSID.FileOperation)]
    [ClassInterface(ClassInterfaceType.None)]
    public class FileOperationClass
    {
    }
}