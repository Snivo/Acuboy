using Acuboy.Helpers;

namespace Acuboy.Core.Processor;

public struct Registers
{
    // 8-bit registers
    public byte A { get; set; }
    public byte B { get; set; }
    public byte C { get; set; }
    public byte D { get; set; }
    public byte E { get; set; }
    private byte f;
    public byte F { get => f; set => value = (byte)(f & 0b1111_0000); }
    public byte H { get; set; }
    public byte L { get; set; }

    // Processor state flags
    /// <summary>Zero flag</summary> ///
    public bool FlagZ 
    {
        get => ByteHelper.GetBit(f, 7);
        set => F = ByteHelper.WriteBit(f, 7, value);
    }
    /// <summary>Subtraction flag</summary> ///
    public bool FlagN
    {
        get => ByteHelper.GetBit(f, 6);
        set => F = ByteHelper.WriteBit(f, 6, value);
    }
    /// <summary>Half-carry flag</summary> ///
    public bool FlagH
    {
        get => ByteHelper.GetBit(f, 5);
        set => F = ByteHelper.WriteBit(f, 5, value);
    }
    /// <summary>Carry flag</summary> ///
    public bool FlagC
    {
        get => ByteHelper.GetBit(f, 4);
        set => F = ByteHelper.WriteBit(f, 4, value);
    }

    // 16-bit Registers
    public ushort AF 
    {
        get => ByteHelper.JoinBytes(A, F); 
        set 
        {
            (byte hi, byte lo) bytes = UShortHelper.Split(value);
            A = bytes.hi;
            F = bytes.lo;
        } 
    }
    public ushort BC
    {
        get => ByteHelper.JoinBytes(B, C); 
        set 
        {
            (byte hi, byte lo) bytes = UShortHelper.Split(value);
            B = bytes.hi;
            C = bytes.lo;
        } 
    }
    public ushort DE 
    {
        get => ByteHelper.JoinBytes(D, E); 
        set 
        {
            (byte hi, byte lo) bytes = UShortHelper.Split(value);
            D = bytes.hi;
            E = bytes.lo;
        } 
    }
    public ushort HL 
    {
        get => ByteHelper.JoinBytes(A, F); 
        set 
        {
            (byte hi, byte lo) bytes = UShortHelper.Split(value);
            H = bytes.hi;
            L = bytes.lo;
        } 
    }
    public ushort PC { get; set; }
    public ushort SP { get; set; }

    public byte GetR8(Register8 register)
    {
        switch(register)
        {
            case Register8.A:
                return A;
            case Register8.B:
                return B;
            case Register8.C:
                return C;
            case Register8.D:
                return D;
            case Register8.E:
                return E;
            case Register8.F:
                return F;
            case Register8.H:
                return H;
            case Register8.L:
                return L;
        }

        return 0;
    }

    public void SetR8(Register8 register, byte val)
    {
        switch(register)
        {
            case Register8.A:
                A = val;
                break;
            case Register8.B:
                B = val;
                break;
            case Register8.C:
                C = val;
                break;
            case Register8.D:
                D = val;
                break;
            case Register8.E:
                E = val;
                break;
            case Register8.F:
                F = val;
                break;
            case Register8.H:
                H = val;
                break;
            case Register8.L:
                L = val;
                break;
        }
    }

    public ushort GetR16(Register16 register)
    {
        switch(register)
        {
            case Register16.AF:
                return AF;
            case Register16.BC:
                return BC;
            case Register16.DE:
                return DE;
            case Register16.HL:
                return HL;
            case Register16.PC:
                return PC;
            case Register16.SP:
                return SP;
        }

        return 0;
    }

    public void SetR16(Register16 register, ushort val)
    {
        switch(register)
        {
            case Register16.AF:
                AF = val;
                break;
            case Register16.BC:
                BC = val;
                break;
            case Register16.DE:
                DE = val;
                break;
            case Register16.HL:
                HL = val;
                break;
            case Register16.PC:
                PC = val;
                break;
            case Register16.SP:
                SP = val;
                break;
        }
    }
}