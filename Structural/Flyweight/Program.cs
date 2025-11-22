using System;
using System.Collections.Generic;

namespace Flyweight;

public class TreeType(string name, ConsoleColor color)
{
  public string Name { get; } = name;
  public ConsoleColor Color { get; } = color;

  public void Draw(int x, int y)
  {
    var previous = Console.ForegroundColor;
    Console.ForegroundColor = Color;
    Console.WriteLine($"Tree {Name} at ({x},{y})");
    Console.ForegroundColor = previous;
  }
}

public class TreeFactory
{
  private readonly Dictionary<string, TreeType> cache = [];

  public TreeType GetTreeType(string name, ConsoleColor color)
  {
    var key = $"{name}-{color}";
    if (!cache.TryGetValue(key, out var type))
    {
      type = new TreeType(name, color);
      cache[key] = type;
    }

    return type;
  }
}

public class Forest
{
  private readonly List<(int x, int y, TreeType type)> trees = [];
  private readonly TreeFactory factory = new();

  public void PlantTree(int x, int y, string name, ConsoleColor color)
  {
    var type = factory.GetTreeType(name, color);
    trees.Add((x, y, type));
  }

  public void Draw()
  {
    Console.WriteLine($"Drawing {trees.Count} trees while sharing flyweights");
    foreach (var (x, y, type) in trees)
    {
      type.Draw(x, y);
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Flyweight Pattern Demo ===");
    Console.WriteLine();

    var forest = new Forest();
    var random = new Random(42);
    for (var i = 0; i < 5; i++)
    {
      forest.PlantTree(random.Next(0, 50), random.Next(0, 50), "Oak", ConsoleColor.Green);
      forest.PlantTree(random.Next(0, 50), random.Next(0, 50), "Birch", ConsoleColor.Yellow);
    }

    forest.Draw();

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
