using System;

namespace State;

public interface IDoorState
{
  void Handle(Door door);
}

public class ClosedState : IDoorState
{
  public void Handle(Door door)
  {
    Console.WriteLine("Door is closed. Opening now...");
    door.SetState(new OpenState());
  }
}

public class OpenState : IDoorState
{
  public void Handle(Door door)
  {
    Console.WriteLine("Door is open. Locking now...");
    door.SetState(new LockedState());
  }
}

public class LockedState : IDoorState
{
  public void Handle(Door door)
  {
    Console.WriteLine("Door is locked. Unlocking...");
    door.SetState(new ClosedState());
  }
}

public class Door
{
  private IDoorState state = new ClosedState();

  public void SetState(IDoorState newState)
  {
    state = newState;
  }

  public void Toggle()
  {
    state.Handle(this);
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== State Pattern Demo ===");
    Console.WriteLine();

    var door = new Door();
    for (var i = 0; i < 5; i++)
    {
      door.Toggle();
    }

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
