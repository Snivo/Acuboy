using System.Collections.ObjectModel;

namespace Acuboy.Core.Processor;

public delegate void Step(); 

struct Instruction 
{
    public readonly string Disassembly;
    public readonly uint TCycles;
    public readonly uint MCycles;

    public readonly ReadOnlyCollection<Step>[] Steps;
}