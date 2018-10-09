namespace SIS.HTTP.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static string Capitalize(this string targetString)
        {
            if (string.IsNullOrEmpty(targetString))
            {
                throw new ArgumentException($"{nameof(targetString)} cannot be null!");
            }
            return char.ToUpper(targetString[0]) + targetString.Substring(1).ToLower();
        }
    }
}
