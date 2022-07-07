namespace Acuboy.Helpers;

public static class ByteHelper
{
    public static ushort JoinBytes(byte hi, byte lo) => (ushort)((hi << 8) | (lo));
    public static bool GetBit(byte val, int bit) => (val & (1 << bit)) != 0;
    public static byte WriteBit(byte val, int bit, bool set) 
    {
        int mask = 1 << bit;
        return (byte)((val & ~mask) | (set ? mask : 0));
    }
}