using System;
using System.Collections.Generic;

namespace Visitor;

public interface IElement
{
  void Accept(IVisitor visitor);
}

public class FileNode(string name, int sizeInKb) : IElement
{
  public string Name { get; } = name;
  public int SizeInKb { get; } = sizeInKb;

  public void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class FolderNode(string name) : IElement
{
  public string Name { get; } = name;
  private readonly List<IElement> children = [];

  public void Add(IElement element) => children.Add(element);

  public IReadOnlyList<IElement> Children => children;

  public void Accept(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}

public interface IVisitor
{
  void Visit(FileNode file);
  void Visit(FolderNode folder);
}

public class SizeCalculator : IVisitor
{
  public int TotalSize { get; private set; }

  public void Visit(FileNode file)
  {
    TotalSize += file.SizeInKb;
  }

  public void Visit(FolderNode folder)
  {
    foreach (var child in folder.Children)
    {
      child.Accept(this);
    }
  }
}

public class TreePrinter : IVisitor
{
  private int depth;

  public void Visit(FileNode file)
  {
    Console.WriteLine(new string(' ', depth * 2) + $"- {file.Name} ({file.SizeInKb}kb)");
  }

  public void Visit(FolderNode folder)
  {
    Console.WriteLine(new string(' ', depth * 2) + $"+ {folder.Name}");
    depth++;
    foreach (var child in folder.Children)
    {
      child.Accept(this);
    }
    depth--;
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Visitor Pattern Demo ===");
    Console.WriteLine();

    var root = new FolderNode("root");
    var documents = new FolderNode("documents");
    documents.Add(new FileNode("resume.pdf", 120));
    documents.Add(new FileNode("budget.xlsx", 80));

    var media = new FolderNode("media");
    media.Add(new FileNode("photo.png", 400));

    root.Add(documents);
    root.Add(media);

    var printer = new TreePrinter();
    root.Accept(printer);

    var calculator = new SizeCalculator();
    root.Accept(calculator);
    Console.WriteLine();
    Console.WriteLine($"Total size: {calculator.TotalSize}kb");

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
