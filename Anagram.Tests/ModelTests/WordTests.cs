using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Anagram.Models;
using System;

namespace Anagram.Tests
{
  [TestClass]
  public class WordTests
  {
    [TestMethod]
    public void WordConstructor_CreatesInstanceOfWord_Word()
    {
      string words = "beard";
      Word word = new Word("bread", words);

      Assert.AreEqual(typeof(Word), word.GetType());
    }

    [TestMethod]
    public void WordConstructor_ReturnsWord_String()
    {
      string myWord = "bread";
      string words = "beard";
      Word word = new Word(myWord, words);

      string result = word.InputWord;

      Assert.AreEqual(myWord, result);
    }

    [TestMethod]
    public void WordConstructor_ReturnsList_List()
    {
      string words = "beard";
      Word word = new Word("bread", words);

      Assert.AreEqual(words, word.PossibleAnagrams);
    }

    [TestMethod]
    public void WordToCharArray_ReturnsArray_Array()
    {
      //Arrange
      string words = "b";
      Word inputWord = new Word("b", words);
      string myWord = "b";
      
      //Act
      char[] charArray = myWord.ToCharArray();
      char[] myCharArray = inputWord.WordToCharArray();

      //Assert
      CollectionAssert.AreEqual(charArray, myCharArray);
    }

    [TestMethod]
    public void WordListToCharArrays_ReturnsList_List()
    {
      //Arrange
      string anagrams = "b";
      Word inputWordObject = new Word("bread", anagrams);
      string possibleAnagram = "b";
      List<char[]> listOfPossibleAnagrams = new List<char[]> {};

      //Act
      List<char[]> listOfSplitAnagrams = inputWordObject.WordListToCharArrays();
      char[] splitAnagram = possibleAnagram.ToCharArray();
      listOfPossibleAnagrams.Add(splitAnagram);

      //Assert
      CollectionAssert.AreEqual(listOfSplitAnagrams[0], listOfPossibleAnagrams[0]);
    }
    [TestMethod]
    public void WordToCharArray_SortList_List()
    {
      //Arrang 
      string words = "bread";
      Word inputWord = new Word("bread", words);
      string myWord = "bread";

      //Act
      char[] charArray = myWord.ToCharArray();
      Array.Sort(charArray);
      char[] myCharArray = inputWord.WordToCharArray();
      
      //Assert
      CollectionAssert.AreEqual(charArray, myCharArray);
    }
    [TestMethod]
    public void WordListToCharArray_SortListOfCharArrays_List()
    {
      //Arrange
      string anagrams = "beard";
      Word inputWordObject = new Word("bread", anagrams);
      string possibleAnagram = "beard";
      List<char[]> listOfPossibleAnagrams = new List<char[]> {};

      //Acct
      List<char[]> listOfSplitAnagrams = inputWordObject.WordListToCharArrays();
      char[] splitAnagram = possibleAnagram.ToCharArray();
      Array.Sort(splitAnagram);
      listOfPossibleAnagrams.Add(splitAnagram);

      //Assert
      CollectionAssert.AreEqual(listOfSplitAnagrams[0], listOfPossibleAnagrams[0]);
    }

    [TestMethod]
    public void WordConstructor_MakesEmptyList_List()
    {
      //Arrange
      string anagrams = "b";
      Word inputWordObject = new Word("bread", anagrams);
      List<string> comparisonList = new List<string> {};

      //Act
      List<string> listOfActualAnagrams = inputWordObject.ActualAnagrams;

      //Assert
      CollectionAssert.AreEqual(comparisonList, listOfActualAnagrams);
    }

    [TestMethod]
    public void IsWordAnagram_ReturnsListOfWords_List()
    {
      //Arrange
      string words = "beard";
      List<string> inputWords = new List<string> {};
      inputWords.Add(words);
      Word inputWord = new Word("bread", words);

      //Act
      char[] wordToArray = inputWord.WordToCharArray();
      List<char[]> wordListToArray = inputWord.WordListToCharArrays();
      inputWord.IsWordAnagram(wordToArray, wordListToArray);

      List<string> actualAnagrams = inputWord.ActualAnagrams;
      //Assert
      CollectionAssert.AreEqual(inputWords, actualAnagrams);
    }
  }
}