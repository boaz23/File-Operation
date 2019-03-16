using System;

namespace FileOperation.Native.Types
{
    [Flags]
    public enum OPPROGDLGF : int
    {
        DEFAULT               = 0x00000000,
        ENABLEPAUSE           = 0x00000080,
        ALLOWUNDO             = 0x00000100,
        DONTDISPLAYSOURCEPATH = 0x00000200,
        DONTDISPLAYDESTPATH   = 0x00000400,
        NOMULTIDAYESTIMATES   = 0x00000800,
        DONTDISPLAYLOCATIONS  = 0x00001000
    }
}