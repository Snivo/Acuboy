namespace Acuboy.Helpers;

public static class UShortHelper
{
    public static (byte low, byte high) Split(ushort val) => ((byte)val, (byte)(val >> 8));
    public static byte GetLow(ushort val) => Split(val).low;
    public static byte GetHigh(ushort val) => Split(val).high;
    public static ushort WriteLow(ushort val, byte low) => ByteHelper.JoinBytes(GetHigh(val), low);
    public static ushort WriteHigh(ushort val, byte high) => ByteHelper.JoinBytes(high, GetLow(val));
}