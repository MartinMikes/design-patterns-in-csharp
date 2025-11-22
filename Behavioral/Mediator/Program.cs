using System;
using System.Collections.Generic;

namespace Mediator;

public interface IChatMediator
{
  void Register(Participant participant);
  void Send(string from, string message);
}

public class ChatRoom : IChatMediator
{
  private readonly Dictionary<string, Participant> participants = [];

  public void Register(Participant participant)
  {
    participants[participant.Name] = participant;
    participant.Mediator = this;
  }

  public void Send(string from, string message)
  {
    foreach (var participant in participants.Values)
    {
      if (participant.Name == from)
      {
        continue;
      }

      participant.Receive(from, message);
    }
  }
}

public abstract class Participant(string name)
{
  public string Name { get; } = name;
  internal IChatMediator? Mediator { get; set; }

  public void Send(string message)
  {
    Mediator?.Send(Name, message);
  }

  public abstract void Receive(string from, string message);
}

public class Developer(string name) : Participant(name)
{
  public override void Receive(string from, string message)
  {
    Console.WriteLine($"[Dev] {from}: {message}");
  }
}

public class Tester(string name) : Participant(name)
{
  public override void Receive(string from, string message)
  {
    Console.WriteLine($"[QA] {from}: {message}");
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Mediator Pattern Demo ===");
    Console.WriteLine();

    var chat = new ChatRoom();
    var dev = new Developer("Alice");
    var tester = new Tester("Bob");
    var lead = new Developer("Carol");

    chat.Register(dev);
    chat.Register(tester);
    chat.Register(lead);

    dev.Send("Unit tests are red.");
    tester.Send("Logging a bug for repro steps.");
    lead.Send("Thanks, pushing a fix now.");

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
