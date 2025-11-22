using System;

namespace ChainOfResponsibility;

public class SupportTicket(string description, int severity)
{
  public string Description
  {
    get;
    private set => field = string.IsNullOrWhiteSpace(value)
      ? throw new ArgumentException("Description cannot be empty", nameof(value))
      : value;
  } = description;

  public int Severity
  {
    get;
    private set => field = value is < 1 or > 3
      ? throw new ArgumentOutOfRangeException(nameof(value), value, "Severity must be between 1 and 3")
      : value;
  } = severity;
}

public abstract class SupportHandler
{
  private SupportHandler? nextHandler;

  public SupportHandler SetNext(SupportHandler handler)
  {
    nextHandler = handler;
    return handler;
  }

  public void Handle(SupportTicket ticket)
  {
    if (!Process(ticket))
    {
      nextHandler?.Handle(ticket);
    }
  }

  protected abstract bool Process(SupportTicket ticket);
}

public class TierOneSupport : SupportHandler
{
  protected override bool Process(SupportTicket ticket)
  {
    if (ticket.Severity <= 1)
    {
      Console.WriteLine($"Tier 1 resolved ticket: {ticket.Description}");
      return true;
    }

    Console.WriteLine("Tier 1 escalated the ticket");
    return false;
  }
}

public class TierTwoSupport : SupportHandler
{
  protected override bool Process(SupportTicket ticket)
  {
    if (ticket.Severity == 2)
    {
      Console.WriteLine($"Tier 2 resolved ticket: {ticket.Description}");
      return true;
    }

    Console.WriteLine("Tier 2 escalated the ticket");
    return false;
  }
}

public class TierThreeSupport : SupportHandler
{
  protected override bool Process(SupportTicket ticket)
  {
    Console.WriteLine($"Tier 3 resolving critical ticket: {ticket.Description}");
    return true;
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Chain of Responsibility Pattern Demo ===");
    Console.WriteLine();

    var tier1 = new TierOneSupport();
    var tier2 = new TierTwoSupport();
    var tier3 = new TierThreeSupport();
    tier1.SetNext(tier2).SetNext(tier3);

    var lowTicket = new SupportTicket("Password reset", 1);
    var mediumTicket = new SupportTicket("API timeout", 2);
    var criticalTicket = new SupportTicket("Production outage", 3);

    tier1.Handle(lowTicket);
    tier1.Handle(mediumTicket);
    tier1.Handle(criticalTicket);

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
