﻿using System.Text;

namespace Leetcode;

internal class Solution
{
    public bool MakeEqual(string[] words)
    {
        int len = words.Length;
        var allWords = new StringBuilder();
        foreach (var word in words)
        {
            allWords.Append(word);
        }
        string allWordsStr = allWords.ToString();
        Dictionary<char, int> characterDict = new();
        for (int i = 0; i < 26; i++)
        {
            char currentLetter = (char)('a' + i);
            characterDict[currentLetter] = allWordsStr.Count(c => c == currentLetter);
            if (characterDict[currentLetter] == 0)
            {
                characterDict.Remove(currentLetter);
            }
        }
        foreach (var letter in characterDict.Keys)
        {
            if (characterDict[letter] % len != 0)
            {
                return false;
            }
        }
        return true;
    }
    public int MaxLengthBetweenEqualCharacters(string s)
    {
        int len = s.Length;
        var dict = new Dictionary<char, List<int>>();

        for (int i = 0; i < len; i++)
        {
            char c = s[i];
            if (dict.ContainsKey(c))
            {
                dict[c].Add(i);
            }
            else
            {
                dict[c] = new List<int>() { i };
            }
        }

        int max = -1;

        foreach (char c in dict.Keys)
        {
            if (dict[c].Count > 1)
            {
                int subStringLength = dict[c].LastOrDefault() - dict[c].FirstOrDefault() - 1;
                if (subStringLength > max)
                {
                    max = subStringLength;
                }
            }
        }
        return max;
    }
}