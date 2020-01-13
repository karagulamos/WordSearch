//  Author: Alexander Karagulamos
//    Date: January 13, 2020
// Comment: https://repl.it/@karagulamos/WordSearch

using System;
using System.Linq;

public class Program
{
  public static void Main(string[] args)
  {
    var search = new WordSearch(new[] { 
      "oath","pea","eat","rain","earn","ear","rate","tar",
      "hire","rake","taken","take","keen","rat","hit","ire",
      "karate","her","neat","near","rather","he","er","ken",
      "eta","at","ate","kata","oar","oat","earner","peasant",
      "tarn","the","eh","el","there","era","en","ta"
    });

    var puzzle = new char[][]{
      new [] { 'o','a','r','n' },
      new [] { 'e','t','a','e' },
      new [] { 'i','h','k','e' },
      new [] { 'r','e','l','n' }
    };

    foreach(var word in search.Solve(puzzle))
      Console.WriteLine(word);    
  }
}

