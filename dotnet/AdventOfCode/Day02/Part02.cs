using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day02
{
    public class Part02
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("./Day02/input.txt")
                .Select(word => word.ToCharArray())
                .ToList();

            if (lines.Count == 0)
                throw new Exception("Whoops... no lines");

            // Assume that the length of each word is the same
            var wordSize = lines[0].Length;

            var result = string.Empty;
            foreach (var line in lines)
            {
                var found = LookUpForSimilarWord(lines, line, wordSize);
                if (string.IsNullOrWhiteSpace(found))
                    continue;

                result = found;
                break; // found the similar word
            }

            Console.WriteLine(string.IsNullOrWhiteSpace(result) ? "Result was not found" : $"Result is {result.ToString()}");
        }

        private static string LookUpForSimilarWord(IEnumerable<char[]> cache, IReadOnlyList<char> charArray, int wordSize)
        {
            var mismatchedIndex = -1;
            foreach (var cacheItem in cache)
            {
                for (var i = 0; i < wordSize; i++)
                {
                    if (cacheItem[i] == charArray[i])
                        continue;

                    // was there already at least one mismatch
                    if (mismatchedIndex > -1)
                    {
                        mismatchedIndex = -1; // reset
                        break;
                    }

                    // there were no mismatches yet. Remembering the first one
                    mismatchedIndex = i;
                }

                // we looped through entire array and found an index where letters differ. This must be it.
                if (mismatchedIndex > -1)
                    break;
            }
            
            // Looks like nothing was found
            if (mismatchedIndex == -1)
                return string.Empty;

            // Let's get the letters which are not containing the mistmatched letter
            var word = charArray.ToList();
            word.RemoveAt(mismatchedIndex);
            return new string(word.ToArray());
        }
    }
}
