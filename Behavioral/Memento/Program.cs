using System;
using System.Collections.Generic;

namespace Memento;

public record DocumentSnapshot(string Content, int Version);

public class Document
{
  public string Content
  {
    get;
    private set => field = value ?? string.Empty;
  } = string.Empty;

  public int Version { get; private set; }

  public void Write(string text)
  {
    Content += text ?? string.Empty;
    Version++;
  }

  public DocumentSnapshot Save() => new(Content, Version);

  public void Restore(DocumentSnapshot snapshot)
  {
    Content = snapshot.Content;
    Version = snapshot.Version;
  }

  public override string ToString() => $"v{Version}: {Content}";
}

public class History
{
  private readonly Stack<DocumentSnapshot> snapshots = [];

  public void Backup(Document doc)
  {
    snapshots.Push(doc.Save());
  }

  public void Undo(Document doc)
  {
    if (snapshots.Count == 0)
    {
      return;
    }

    var snapshot = snapshots.Pop();
    doc.Restore(snapshot);
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Memento Pattern Demo ===");
    Console.WriteLine();

    var document = new Document();
    var history = new History();

    document.Write("Hello");
    history.Backup(document);

    document.Write(", world");
    history.Backup(document);

    document.Write("! Breaking change.");
    Console.WriteLine($"Current: {document}");

    history.Undo(document);
    Console.WriteLine($"After undo: {document}");

    history.Undo(document);
    Console.WriteLine($"Restored: {document}");

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
