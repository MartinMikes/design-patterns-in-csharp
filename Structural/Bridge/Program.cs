using System;

namespace Bridge;

public interface IRenderer
{
  void RenderCircle(float x, float y, float radius);
}

public class VectorRenderer : IRenderer
{
  public void RenderCircle(float x, float y, float radius)
  {
    Console.WriteLine($"Drawing vector circle at ({x},{y}) radius {radius}");
  }
}

public class RasterRenderer : IRenderer
{
  public void RenderCircle(float x, float y, float radius)
  {
    Console.WriteLine($"Rasterizing circle to pixels at ({x},{y}) radius {radius}");
  }
}

public abstract class Shape(IRenderer renderer)
{
  protected IRenderer Renderer { get; } = renderer;

  public abstract void Draw();
}

public class Circle(float x, float y, float radius, IRenderer renderer) : Shape(renderer)
{
  public override void Draw()
  {
    Renderer.RenderCircle(x, y, radius);
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Bridge Pattern Demo ===");
    Console.WriteLine();

    Shape circle = new Circle(10, 10, 5, new VectorRenderer());
    circle.Draw();

    circle = new Circle(25, 5, 12, new RasterRenderer());
    circle.Draw();

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
