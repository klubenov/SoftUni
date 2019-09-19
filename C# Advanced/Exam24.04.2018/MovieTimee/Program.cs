using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieTimee
{
    public class Program
    {
        static void Main(string[] args)
        {
            string targetGenre = Console.ReadLine();
            string durationPreference = Console.ReadLine();

            string input;

            List<Movie> movies = new List<Movie>();

            while ((input=Console.ReadLine())!= "POPCORN!")
            {
                var movieData = input.Split('|');
                string name = movieData[0];
                string genre = movieData[1];
                var timeData = movieData[2].Split(':');
                int hours = int.Parse(timeData[0]);
                int minutes = int.Parse(timeData[1]);
                int seconds = int.Parse(timeData[2]);

                var newMovie = new Movie(name, genre, hours, minutes, seconds);
                movies.Add(newMovie);
            }

            var sortedMovies = new List<Movie>();

            if (durationPreference=="Short")
            {
                sortedMovies = movies.Where(m => m.Genre == targetGenre).OrderBy(m => m.DurationInSeconds).ToList();
            }
            else
            {
                sortedMovies = movies.Where(m => m.Genre == targetGenre).OrderByDescending(m => m.DurationInSeconds).ToList();
            }

            foreach (var movie in sortedMovies)
            {
                Console.WriteLine($"{movie.Name}");
                input = Console.ReadLine();
                if (input=="Yes")
                {
                    
                    Console.WriteLine($"We're watching {movie.Name} - {movie.timeSpan:hh\\:mm\\:ss}");

                    var totalDuration = movies.Sum(m => m.DurationInSeconds);

                    int totalHours = totalDuration / 3600;
                    int totalMinutes = (totalDuration - totalHours * 3600) / 60;
                    int totalSeconds = (totalDuration - totalHours * 3600 - totalMinutes * 60);

                    TimeSpan totaSpan = new TimeSpan(totalHours, totalMinutes, totalSeconds);

                    Console.WriteLine($"Total Playlist Duration: {totaSpan:hh\\:mm\\:ss}");
                    Environment.Exit(0);
                }
            }
        }
    }

    public class Movie
    {
        public Movie(string name, string genre, int hours, int minutes, int seconds)
        {
            this.Name = name;
            this.Genre = genre;
            this.timeSpan = new TimeSpan(hours, minutes, seconds);
        }

        public string Name { get; set; }

        public TimeSpan timeSpan { get; set; }

        public string  Genre { get; set; }

        public int DurationInSeconds => this.timeSpan.Seconds + this.timeSpan.Minutes * 60 + this.timeSpan.Hours * 3600;
    }
}
