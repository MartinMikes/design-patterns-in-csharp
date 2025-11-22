using System;

namespace TemplateMethod;

public abstract class DataExporter
{
  public void Export()
  {
    Connect();
    var data = Query();
    Format(data);
    Disconnect();
  }

  protected abstract void Connect();
  protected abstract string Query();
  protected abstract void Format(string data);
  protected virtual void Disconnect()
  {
    Console.WriteLine("Disconnected.");
  }
}

public class CsvExporter : DataExporter
{
  protected override void Connect() => Console.WriteLine("Opening CSV file...");

  protected override string Query() => "Name,Role\nAlice,Developer\nBob,Tester";

  protected override void Format(string data)
  {
    Console.WriteLine("Writing CSV:\n" + data);
  }
}

public class JsonExporter : DataExporter
{
  protected override void Connect() => Console.WriteLine("Opening JSON stream...");

  protected override string Query() => "[{\"name\":\"Alice\",\"role\":\"Developer\"}]";

  protected override void Format(string data)
  {
    Console.WriteLine("Serializing JSON:\n" + data);
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Template Method Pattern Demo ===");
    Console.WriteLine();

    DataExporter exporter = new CsvExporter();
    exporter.Export();

    Console.WriteLine();
    exporter = new JsonExporter();
    exporter.Export();

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
