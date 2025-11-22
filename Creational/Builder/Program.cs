using System;
using System.Text;

namespace Builder;
// Product
public class Computer
{
    // Using C# 14 field keyword for validation
    public string CPU
    {
        get;
        set => field = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string RAM
    {
        get;
        set => field = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Storage
    {
        get;
        set => field = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string? GPU { get; set; }
    public string? OS { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Computer Configuration:");
        sb.AppendLine($"  CPU: {CPU}");
        sb.AppendLine($"  RAM: {RAM}");
        sb.AppendLine($"  Storage: {Storage}");
        if (!string.IsNullOrEmpty(GPU))
            sb.AppendLine($"  GPU: {GPU}");
        if (!string.IsNullOrEmpty(OS))
            sb.AppendLine($"  OS: {OS}");
        return sb.ToString();
    }
}

// Builder interface
public interface IComputerBuilder
{
    IComputerBuilder SetCPU(string cpu);
    IComputerBuilder SetRAM(string ram);
    IComputerBuilder SetStorage(string storage);
    IComputerBuilder SetGPU(string gpu);
    IComputerBuilder SetOS(string os);
    Computer Build();
}

// Concrete Builder
public class ComputerBuilder : IComputerBuilder
{
    private Computer computer = new Computer();

    public IComputerBuilder SetCPU(string cpu)
    {
        computer.CPU = cpu;
        return this;
    }

    public IComputerBuilder SetRAM(string ram)
    {
        computer.RAM = ram;
        return this;
    }

    public IComputerBuilder SetStorage(string storage)
    {
        computer.Storage = storage;
        return this;
    }

    public IComputerBuilder SetGPU(string gpu)
    {
        computer.GPU = gpu;
        return this;
    }

    public IComputerBuilder SetOS(string os)
    {
        computer.OS = os;
        return this;
    }

    public Computer Build()
    {
        return computer;
    }
}

// Director (optional - demonstrates common configurations)
public class ComputerDirector
{
    public Computer BuildGamingPC(IComputerBuilder builder)
    {
        return builder
            .SetCPU("Intel Core i9-13900K")
            .SetRAM("32GB DDR5")
            .SetStorage("2TB NVMe SSD")
            .SetGPU("NVIDIA RTX 4090")
            .SetOS("Windows 11")
            .Build();
    }

    public Computer BuildOfficePC(IComputerBuilder builder)
    {
        return builder
            .SetCPU("Intel Core i5-13400")
            .SetRAM("16GB DDR4")
            .SetStorage("512GB SSD")
            .SetOS("Windows 11 Pro")
            .Build();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Builder Pattern Demo ===");
        Console.WriteLine();

        var director = new ComputerDirector();

        // Build a gaming PC using director
        Console.WriteLine("Building Gaming PC:");
        var gamingPC = director.BuildGamingPC(new ComputerBuilder());
        Console.WriteLine(gamingPC);

        // Build an office PC using director
        Console.WriteLine("Building Office PC:");
        var officePC = director.BuildOfficePC(new ComputerBuilder());
        Console.WriteLine(officePC);

        // Build a custom PC without director
        Console.WriteLine("Building Custom PC:");
        var customPC = new ComputerBuilder()
            .SetCPU("AMD Ryzen 9 7950X")
            .SetRAM("64GB DDR5")
            .SetStorage("4TB NVMe SSD")
            .SetGPU("AMD Radeon RX 7900 XTX")
            .Build();
        Console.WriteLine(customPC);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
