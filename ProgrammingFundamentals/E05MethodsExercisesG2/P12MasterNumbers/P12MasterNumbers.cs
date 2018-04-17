using System;

namespace P12MasterNumbers
{
    class P12MasterNumbers
    {
        static bool IsPalindrome(int num)
        {
            short digitNum = 0;
            int originalNum = num;
            int digitChecker = num;
            int revertedNum = 0;
            while (digitChecker > 0)
            {
                digitChecker = digitChecker / 10;
                digitNum++;
            }
            for (int i = 1; i <= digitNum; i++)
            {
                int currentDigit = num % 10;
                revertedNum = revertedNum + currentDigit * (int) Math.Pow(10, (digitNum - i));
                num = num / 10;
            }
            if (originalNum == revertedNum) return true;
            return false;
        }

        //static bool IsPalindrome(int num)
        //{
        //    string numString = num.ToString();
        //    char[] numArray = numString.ToCharArray();
        //    Array.Reverse(numArray);
        //    string checkString = new string(numArray);
        //    if (checkString == numString)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        static bool SumOfDigits(int num)
        {
            int digitCount = 0;
            while (num >0)
            {
                int currentDigit = num % 10;
                digitCount += currentDigit;
                num = num / 10;
            }
            if (digitCount % 7 == 0) return true;
            return false;
        }

        static bool ContainsEvenDigits(int num)
        {
            while (num > 0)
            {
                int currentDigit = num % 10;
                if (currentDigit % 2 == 0) return true;
                num = num / 10;
            }
            return false;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (IsPalindrome(i) && SumOfDigits(i) && ContainsEvenDigits(i))
                    Console.WriteLine(i);
            }
        }
    }
}
