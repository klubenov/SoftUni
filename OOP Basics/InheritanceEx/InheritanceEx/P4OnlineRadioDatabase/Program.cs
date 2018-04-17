using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        int songCount = int.Parse(Console.ReadLine());

        var songList = new List<Song>();

        for (int i = 0; i < songCount; i++)
        {
            var songData = Console.ReadLine().Split(';');
            var artistName = songData[0];
            var songName = songData[1];
            var songLength = songData[2];

            try
            {
                var artist = new Artist(artistName);
                var newSong = new Song(songName,artist,songLength);
                songList.Add(newSong);
                Console.WriteLine("Song added.");
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        var totalSongSeconds = 0;
        var totalSongMinutes = 0;
        foreach (var song in songList)
        {
            totalSongMinutes += song.GetMinutes();
            totalSongSeconds += song.GetSeconds();
        }
        var cumulativeSongsDuration = new TimeSpan(0,totalSongMinutes,totalSongSeconds);

        Console.WriteLine($"Songs added: {songList.Count}");
        Console.WriteLine($"Playlist length: {cumulativeSongsDuration.Hours}h {cumulativeSongsDuration.Minutes}m {cumulativeSongsDuration.Seconds}s");
    }
}

