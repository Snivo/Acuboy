using Acuboy.Core.Processor;

namespace Acuboy.Core;

public class CPU
{
    public Registers Registers = new();
    public ulong Ticks { get; private set; }
    private IAddressable bus;

    public void Tick()
    {
        Ticks++;

        if (Ticks % 4 == 0)
            MTick();
    }

    private void MTick()
    {
        
    }

    private byte InternalRead(ushort addr) => bus.Read(addr);

    private void InternalWrite(ushort addr, byte value) => bus.Write(addr, value);

    public CPU(Bus bus)
    {
        this.bus = bus;
    }
}