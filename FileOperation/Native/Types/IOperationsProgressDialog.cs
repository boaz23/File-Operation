using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Utility;
using Utility.Interop;
using Utility.Interop.Native.Types;

namespace FileOperation.Native.Types
{
    [ComImport]
    [Guid(IID.IOperationsProgressDialog)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOperationsProgressDialog
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void StartProgressDialog
        (
            [In] IntPtr hwndOwner,

            [In]
            [PossibleTypes(typeof(OPPROGDLGF), typeof(PROGDLGF))]
            int flags
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void StopProgressDialog();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetOperation([In] SPACTION action);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetMode([In] PDM mode);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UpdateProgress
        (
            [In] long ullPointsCurrent,
            [In] long ullPointsTotal,
            [In] long ullSizeCurrent,
            [In] long ullSizeTotal,
            [In] long ullItemsCurrent,
            [In] long ullItemsTotal
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UpdateLocations
        (
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiSource,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiTarget,
            [In] [MarshalAs(UnmanagedType.Interface)] IShellItem psiItem
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ResetTimer();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void PauseTimer();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ResumeTimer();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMilliseconds([Out] out long pullElapsed, [Out] out long pullRemaining);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: UnmanagedDefinition("PDOPSTATUS *popstatus")]
        PDOPS GetOperationStatus();
    }
}