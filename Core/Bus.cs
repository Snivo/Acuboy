namespace Acuboy.Core;

public class Bus : IAddressable
{
    public byte Read(ushort addr)
    {
        return 0x00;
    }

    public void Write(ushort addr, byte value)
    {

    }
}