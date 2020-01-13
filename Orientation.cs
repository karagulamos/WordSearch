//  Author: Alexander Karagulamos
//    Date: January 13, 2019
// Comment: WordSearch

internal struct Orientation
{
  internal Orientation(int row, int col)
  {
    Row = row;
    Col = col;
  }
  
  public int Row { get; }
  public int Col { get; }
}