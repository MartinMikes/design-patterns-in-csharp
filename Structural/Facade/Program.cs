using System;

namespace Facade;

public class Amplifier
{
  public void On() => Console.WriteLine("Amplifier on");
  public void SetVolume(int level) => Console.WriteLine($"Volume set to {level}");
  public void Off() => Console.WriteLine("Amplifier off");
}

public class Projector
{
  public void On() => Console.WriteLine("Projector on");
  public void WideScreenMode() => Console.WriteLine("Projector set to widescreen");
  public void Off() => Console.WriteLine("Projector off");
}

public class StreamingPlayer
{
  public void On() => Console.WriteLine("Streaming player on");
  public void Play(string movie) => Console.WriteLine($"Playing {movie}");
  public void Stop() => Console.WriteLine("Stopping stream");
  public void Off() => Console.WriteLine("Streaming player off");
}

public class HomeTheaterFacade(Amplifier amp, Projector projector, StreamingPlayer player)
{
  public void WatchMovie(string movie)
  {
    Console.WriteLine("Get ready to watch a movie...");
    amp.On();
    amp.SetVolume(5);
    projector.On();
    projector.WideScreenMode();
    player.On();
    player.Play(movie);
  }

  public void EndMovie()
  {
    Console.WriteLine("Shutting movie theater down...");
    player.Stop();
    player.Off();
    projector.Off();
    amp.Off();
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Facade Pattern Demo ===");
    Console.WriteLine();

    var facade = new HomeTheaterFacade(new Amplifier(), new Projector(), new StreamingPlayer());
    facade.WatchMovie("The Coding Adventure");
    Console.WriteLine();
    facade.EndMovie();

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
