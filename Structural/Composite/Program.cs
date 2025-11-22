using System;
using System.Collections.Generic;

namespace Composite;

public interface IGraphic
{
  void Draw();
}

public class Dot(int x, int y) : IGraphic
{
  public void Draw()
  {
    Console.WriteLine($"Drawing dot at ({x},{y})");
  }
}

public class CompositeGraphic(string name) : IGraphic
{
  private readonly List<IGraphic> children = [];
  public string Name { get; } = name;

  public void Add(IGraphic graphic) => children.Add(graphic);

  public void Draw()
  {
    Console.WriteLine($"Group {Name} contains {children.Count} items");
    foreach (var child in children)
    {
      child.Draw();
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Composite Pattern Demo ===");
    Console.WriteLine();

    var circleGroup = new CompositeGraphic("CircleGroup");
    circleGroup.Add(new Dot(1, 1));
    circleGroup.Add(new Dot(2, 2));

    var drawing = new CompositeGraphic("Drawing");
    drawing.Add(circleGroup);
    drawing.Add(new Dot(5, 5));

    drawing.Draw();

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
