using System;
using System.Collections.Generic;

namespace Prototype;

public abstract class Shape
{
  public string Color
  {
    get;
    set => field = string.IsNullOrWhiteSpace(value)
      ? throw new ArgumentException("Color cannot be empty", nameof(value))
      : value;
  } = "Black";
  public abstract Shape Clone();
  public abstract void Draw();
}

public class Circle : Shape
{
  public int Radius
  {
    get;
    set => field = value <= 0
      ? throw new ArgumentOutOfRangeException(nameof(value), value, "Radius must be positive")
      : value;
  }

  public override Shape Clone() => new Circle { Radius = Radius, Color = Color };

  public override void Draw()
  {
    Console.WriteLine($"Circle ({Color}) radius={Radius}");
  }
}

public class Rectangle : Shape
{
  public int Width
  {
    get;
    set => field = value <= 0
      ? throw new ArgumentOutOfRangeException(nameof(value), value, "Width must be positive")
      : value;
  }

  public int Height
  {
    get;
    set => field = value <= 0
      ? throw new ArgumentOutOfRangeException(nameof(value), value, "Height must be positive")
      : value;
  }

  public override Shape Clone() => new Rectangle { Width = Width, Height = Height, Color = Color };

  public override void Draw()
  {
    Console.WriteLine($"Rectangle ({Color}) {Width}x{Height}");
  }
}

public class ShapeRegistry
{
  private readonly Dictionary<string, Shape> prototypes = [];

  public void Register(string key, Shape shape) => prototypes[key] = shape;

  public Shape Create(string key) => prototypes[key].Clone();
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Prototype Pattern Demo ===");
    Console.WriteLine();

    var registry = new ShapeRegistry();
    registry.Register("small-circle", new Circle { Radius = 10, Color = "Blue" });
    registry.Register("banner", new Rectangle { Width = 120, Height = 30, Color = "Green" });

    var clonedCircle = registry.Create("small-circle");
    clonedCircle.Color = "Red";

    var clonedRectangle = registry.Create("banner");
    clonedRectangle.Draw();
    clonedCircle.Draw();

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
