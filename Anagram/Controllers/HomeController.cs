using Microsoft.AspNetCore.Mvc;
using Anagram.Models;
using System.Collections.Generic;

namespace Anagram.Controllers
{
  public class Homecontroller : Controller
  {
    [Route("/")]
    public ActionResult Form()
    {
      return View();
    }

    [Route("/answer")]
    public ActionResult Answer(string word, string list)
    {
      Word myWord = new Word(word, list);
      char[] wordArray = myWord.WordToCharArray();
      List<char[]> sortedListOfPossibleAnagrams = myWord.WordListToCharArrays();
      myWord.IsWordAnagram(wordArray, sortedListOfPossibleAnagrams);
      return View(myWord);
    }
  }
}