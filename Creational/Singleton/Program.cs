using System;

namespace Singleton;

/// <summary>
/// Thread-safe Singleton implementation using lazy initialization
/// Compatible with .NET 10 and C# 14
/// </summary>
public sealed class Singleton
{
    private static readonly Lazy<Singleton> lazy =
        new Lazy<Singleton>(() => new Singleton());

    public static Singleton Instance { get { return lazy.Value; } }

    private Singleton()
    {
        Console.WriteLine("Singleton instance created");
    }

    public void DoSomething()
    {
        Console.WriteLine("Singleton is doing something");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Singleton Pattern Demo ===");
        Console.WriteLine();

        // Get the singleton instance
        Singleton s1 = Singleton.Instance;
        s1.DoSomething();

        // Try to get another instance
        Singleton s2 = Singleton.Instance;
        s2.DoSomething();

        // Verify they are the same instance
        if (s1 == s2)
        {
            Console.WriteLine();
            Console.WriteLine("Both variables reference the same Singleton instance");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
