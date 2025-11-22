using System;

namespace Proxy;

public interface IImage
{
  void Display();
}

public class RealImage(string fileName) : IImage
{
  public string FileName { get; } = fileName;

  private void LoadFromDisk()
  {
    Console.WriteLine($"Loading {FileName} from disk...");
  }

  public void Display()
  {
    Console.WriteLine($"Displaying {FileName}");
  }
}

public class ImageProxy(string fileName) : IImage
{
  private RealImage? realImage;

  public void Display()
  {
    realImage ??= new RealImage(fileName);
    realImage.Display();
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Proxy Pattern Demo ===");
    Console.WriteLine();

    IImage image = new ImageProxy("diagram.png");
    Console.WriteLine("First call will load the image:");
    image.Display();

    Console.WriteLine();
    Console.WriteLine("Second call uses cached image:");
    image.Display();

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
