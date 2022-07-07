namespace Acuboy.Core;

public interface IAddressable
{
    public byte Read(ushort addr);
    public void Write(ushort addr, byte value);
}