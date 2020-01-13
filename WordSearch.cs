//  Author: Alexander Karagulamos
//    Date: January 13, 2019
// Comment: WordSearch

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WordSearch 
{
    private const char Checked = '%';
    
    private readonly Orientation[] _directions;
    private readonly WordDictionary _dictionary;
    
    public WordSearch(string[] words)
    {
        _directions = new Orientation[] {
            new Orientation(-1, 0), new Orientation(0, 1), 
            new Orientation(1, 0), new Orientation(0, -1)
        };

        _dictionary = new WordDictionary();
        
        foreach(var word in words)
          _dictionary.Add(word);
    }
    
    public IEnumerable<string> Solve(char[][] board) => Search(board).Distinct();
    
    private IEnumerable<string> Search(char[][] board)
    {
        for(int row = 0; row < board.Length; row++)
        {
            for(int col = 0; col < board[0].Length; col++)
            {
                var node = _dictionary.GetNode(board[row][col]);
                
                if(node == WordDictionary.None) 
                    continue;
                
                var prefix = new StringBuilder($"{board[row][col]}");
                
                foreach(var word in Search(board, row, col, node, prefix))
                    yield return word;                
            }
        }
    }
    
    private IEnumerable<string> Search(char[][] board, int row, int col, WordDictionary.Node node, StringBuilder prefix)
    {        
        if(node.IsWordEnd)
            yield return prefix.ToString();
        
        var toUncheck = board[row][col]; 
        
        board[row][col] = Checked;
                
        for(var idx = 0; idx < _directions.Length; idx++)
        {
            var r = _directions[idx].Row + row;
            var c = _directions[idx].Col + col;
            
            if(r < 0 || c < 0 || r >= board.Length || c >= board[0].Length)
                continue;
                
            if(board[r][c] == Checked)
                continue;                       
            
            var next = WordDictionary.GetIndex(board[r][c]);
            
            if(node.Children[next] == WordDictionary.None) 
                continue;
                                    
            foreach(var word in Search(board, r, c, node.Children[next], prefix.Append(board[r][c])))
                yield return word; 
        }
        
        board[row][col] = toUncheck;
        prefix.Length--;
    }
}