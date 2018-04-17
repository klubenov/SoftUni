using System;

namespace P19TheaThePhotographer
{
    class P19TheaThePhotographer
    {
        static void Main(string[] args)
        {
            int totalPhotos = int.Parse(Console.ReadLine());
            int filterTime = int.Parse(Console.ReadLine());
            int filterFactor = int.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());
            long afterFilterPhotos = (long)Math.Ceiling(filterFactor * totalPhotos / 100.0);
            long totalFilterTime = (long)filterTime * totalPhotos;
            long totalUploadTime = (long)afterFilterPhotos * uploadTime;
            long totalTime = totalFilterTime + totalUploadTime;
            TimeSpan formatedTime = TimeSpan.FromSeconds(totalTime);
            string format = formatedTime.ToString(@"d\:hh\:mm\:ss");
            Console.WriteLine(format);
        }
    }
}
