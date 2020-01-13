public class WordDictionary
{
    private Node _root;
    
    public WordDictionary() => _root = new Node();
    
    public Node GetNode(char letter) => _root.Children[GetIndex(letter)];
    
    public void Add(string word)
    {
        if(string.IsNullOrEmpty(word)) return;
        
        var current = _root;
        
        foreach(var letter in word)
        {
            var index = GetIndex(letter);
                
            if(current.Children[index] == default(Node))
            {
              current.Children[index] = new Node();
            }
            
            current = current.Children[index];
        }
        
        current.IsWordEnd = true;
    }
        
    public static int GetIndex(char letter) => letter - 'a';    
    
    public class Node
    {
        public Node[] Children { get; } = new Node[26];
        public bool IsWordEnd { get; set; }
    }
}