using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace LabWork_Strings
{
    public static class StringsTasks
    {
        public static void Task1Variant6()
        {
            string inputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Text Files\input.io");
            string outputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Text Files\output.io");

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"File at [{inputFilePath}] doesn't exist! Aborting.");
                return;
            }

            string input;
            using (StreamReader sr = File.OpenText(inputFilePath))
            {
                Console.WriteLine("Extracted Text:\n");
                Console.WriteLine(input = sr.ReadToEnd());
                Console.WriteLine();
            }

            var words = Regex.Split(input, @"\s+").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            int maxLength = 0;
            int longestWordIndex = -1;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxLength)
                {
                    maxLength = words[i].Length;
                    longestWordIndex = i;
                }
            }

            if (longestWordIndex != -1)
            {
                Console.WriteLine($"Longest word: {words[longestWordIndex]}");
                Console.WriteLine($"Word #{longestWordIndex + 1}");
                Console.WriteLine($"Length: {maxLength} symbols.");
            }
            else
            {
                Console.WriteLine("No words found.");
            }

            using (StreamWriter sw = File.CreateText(outputFilePath))
            {
                sw.Write(longestWordIndex + 1);
            }
        }
    }
}
