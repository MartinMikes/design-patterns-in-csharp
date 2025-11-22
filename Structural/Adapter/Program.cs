using System;

namespace Adapter;

// Target interface that client expects
public interface IMediaPlayer
{
    void Play(string audioType, string fileName);
}

// Adaptee - Advanced player with different interface
public class AdvancedMediaPlayer
{
    public void PlayMp4(string fileName)
    {
        Console.WriteLine($"Playing MP4 file: {fileName}");
    }

    public void PlayVlc(string fileName)
    {
        Console.WriteLine($"Playing VLC file: {fileName}");
    }
}

// Adapter - Makes AdvancedMediaPlayer compatible with IMediaPlayer
public class MediaAdapter(string audioType) : IMediaPlayer
{
    // Using C# 14 field keyword
    private AdvancedMediaPlayer AdvancedPlayer { get; init; } = new AdvancedMediaPlayer();

    public void Play(string audioType, string fileName)
    {
        if (audioType.Equals("mp4", StringComparison.OrdinalIgnoreCase))
        {
            AdvancedPlayer.PlayMp4(fileName);
        }
        else if (audioType.Equals("vlc", StringComparison.OrdinalIgnoreCase))
        {
            AdvancedPlayer.PlayVlc(fileName);
        }
    }
}

// Client class
public class AudioPlayer : IMediaPlayer
{
    private MediaAdapter? mediaAdapter;

    public void Play(string audioType, string fileName)
    {
        // Built-in support for mp3
        if (audioType.Equals("mp3", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Playing MP3 file: {fileName}");
        }
        // Use adapter for other formats
        else if (audioType.Equals("mp4", StringComparison.OrdinalIgnoreCase) ||
                 audioType.Equals("vlc", StringComparison.OrdinalIgnoreCase))
        {
            mediaAdapter = new MediaAdapter(audioType);
            mediaAdapter.Play(audioType, fileName);
        }
        else
        {
            Console.WriteLine($"Invalid media type: {audioType}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Adapter Pattern Demo ===");
        Console.WriteLine();

        AudioPlayer audioPlayer = new AudioPlayer();

        audioPlayer.Play("mp3", "song.mp3");
        audioPlayer.Play("mp4", "video.mp4");
        audioPlayer.Play("vlc", "movie.vlc");
        audioPlayer.Play("avi", "video.avi");

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
