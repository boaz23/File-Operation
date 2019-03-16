using System;

namespace FileOperation.Native.Types
{
    [Flags]
    public enum PROGDLGF : int
    {
        NORMAL          = 0x00000000,
        MODAL           = 0x00000001,
        AUTOTIME        = 0x00000002,
        NOTIME          = 0x00000004,
        NOMINIMIZE      = 0x00000008,
        NOPROGRESSBAR   = 0x00000010,
        MARQUEEPROGRESS = 0x00000020,
        NOCANCEL        = 0x00000040
    }
}