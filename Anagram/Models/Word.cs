using System;
using System.Collections.Generic;

namespace Anagram.Models
{
  public class Word
  {
    public string InputWord { get; set; }
    public string Header { get; set; }
    public List<string> ActualAnagrams { get; set; } = new List<string> {};
    public string PossibleAnagrams { get; }
    public string[] PossibleAnagramsArray { get; set; } 

    public Word(string inputWord, string possibleAnagrams)
    {
      InputWord = inputWord;
      Header = "";
      PossibleAnagrams = possibleAnagrams;
      PossibleAnagramsArray = possibleAnagrams.Split(" ");
      ActualAnagrams = new List<string> {};
    }

    public char[] WordToCharArray()
    {
      char[] inputWordArray = InputWord.ToCharArray();
      Array.Sort(inputWordArray);
      return inputWordArray;
    }

    public List<char[]> WordListToCharArrays()
    {
      List<char[]> result = new List<char[]> {};
      foreach (string currentWord in PossibleAnagramsArray)
      {
        char[] charArray = currentWord.ToCharArray();
        Array.Sort(charArray);
        result.Add(charArray);
      }
      return result;
    }

    public void IsWordAnagram(char[] wordArray, List<char[]> inputWordsArrays)
    {
      string sortedWord = new String(wordArray);
      for(int i=0; i < inputWordsArrays.Count; i++)
      {
        string sortedListWord = new String(inputWordsArrays[i]);
        if (sortedWord == sortedListWord)
        {
          ActualAnagrams.Add(PossibleAnagramsArray[i]);
        }
      }
      if (ActualAnagrams.Count == 0)
      {
        Header = "No anagrams here!";
      }
      else
      {
        Header = "The following words are anagrams:";
      }
    }
  }
}