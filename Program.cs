﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Word_Counter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File path: ");
            string path = Console.ReadLine();
            Console.WriteLine("\nWords in file by frequency: \n");

            var words = File.ReadAllText(path).
                Split(new char[] { ',', ' ', '!', '.', ';', ':', '?', '#', '@' }, StringSplitOptions.RemoveEmptyEntries).
                Where(x => !string.IsNullOrEmpty(x) && x.All(char.IsLetter)).
                Select(x => x.ToLower());

            var wordCount = words.GroupBy(word => word).
                OrderByDescending(group => group.Count());

            foreach (var group in wordCount)
            {
                Console.WriteLine($"{group.Key} was found {group.Count()} times");
            }
        }
    }
}
