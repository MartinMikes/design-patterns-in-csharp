using System;
using System.Collections.Generic;

namespace Iterator;

public interface IIterator<T>
{
  bool HasNext();
  T Current { get; }
  void MoveNext();
}

public interface IAggregate<T>
{
  IIterator<T> CreateForwardIterator();
  IIterator<T> CreateReverseIterator();
}

public class Playlist : IAggregate<string>
{
  private readonly List<string> tracks = [];

  public void AddTrack(string title) => tracks.Add(title);

  public IIterator<string> CreateForwardIterator() => new PlaylistIterator(tracks, reverse: false);

  public IIterator<string> CreateReverseIterator() => new PlaylistIterator(tracks, reverse: true);
}

public class PlaylistIterator(IList<string> items, bool reverse) : IIterator<string>
{
  private int index = reverse ? items.Count : -1;

  public bool HasNext() => reverse ? index > 0 : index < items.Count - 1;

  public string Current => items[index];

  public void MoveNext()
  {
    index += reverse ? -1 : 1;
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Iterator Pattern Demo ===");
    Console.WriteLine();

    var playlist = new Playlist();
    playlist.AddTrack("Intro");
    playlist.AddTrack("Verse");
    playlist.AddTrack("Chorus");
    playlist.AddTrack("Outro");

    Console.WriteLine("Playing forward:");
    var forward = playlist.CreateForwardIterator();
    while (forward.HasNext())
    {
      forward.MoveNext();
      Console.WriteLine($"-> {forward.Current}");
    }

    Console.WriteLine();
    Console.WriteLine("Playing in reverse:");
    var backward = playlist.CreateReverseIterator();
    while (backward.HasNext())
    {
      backward.MoveNext();
      Console.WriteLine($"<- {backward.Current}");
    }

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
