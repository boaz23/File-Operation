using Utility.Interop;

namespace FileOperation.Native.Types
{
    [UnmanagedDefinition("PDOPSTATUS")]
    public enum PDOPS
    {
        RUNNING   = 1,
        PAUSED    = 2,
        CANCELLED = 3,
        STOPPED   = 4,
        ERRORS    = 5
    }
}