using System;
using System.Linq;

public class Program
{
  public static void Main(string[] args)
  {
    var search = new WordSearch(new[] { 
      "oath","pea","eat","rain","earn","ear","rate","tar",
      "hire","rake","taken","take","keen","rat","hit"
    });

    var puzzle = new char[][]{
      new [] { 'o','a','r','n' },
      new [] { 'e','t','a','e' },
      new [] { 'i','h','k','e' },
      new [] { 'r','e','l','n' }
    };

    foreach(var word in search.Solve(puzzle).OrderBy(w => w))
      Console.WriteLine(word);    
  }
}

