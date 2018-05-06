using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace HW10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] readText = File.ReadAllLines(@"E:\HW9.Marshalek.txt");
            int stringLength = 0;
            int max = 0;
            int maxIndex = 0;
            int min = 10000;
            int minIndex = 0;
            for (int i = 0; i < readText.Length; i++)
            {
                stringLength = readText[i].Length;
                if (stringLength > max)
                {
                    max = stringLength;
                    maxIndex = i + 1;
                }
                if (stringLength < min)
                {
                    min = stringLength;
                    minIndex = i + 1;
                }
                Console.WriteLine("String number {0} has {1} characters.", i+1, stringLength);
            }
            Console.WriteLine("The longest string is number {0}, has {1} characters.", maxIndex, max);
            Console.WriteLine("The shortest string is number {0}, has {1} characters.", minIndex, min);
            string stringPattern = @"var";
            foreach (string x in readText)
            {
                Match aResult = Regex.Match(x, stringPattern);
                if (aResult.Success)
                    Console.WriteLine("String [{0}] has word var in it.", x);
            }
            Console.ReadLine();
        }
    }
}
