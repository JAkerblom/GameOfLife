using System;
using System.Collections.Generic;

namespace GameOfLife
{
  public class Simulator
  {
    private GUISettings _gUISettings;
    //private List<Cell> _cells;
    private Dictionary<Tuple<int, int>, Cell> _cells;

    public Simulator(GUISettings gUISettings)
    {
      _gUISettings = gUISettings;
      _cells = new Dictionary<Tuple<int, int>, Cell>();
      CreateCells();
    }

    public void LetAnEpochPass()
    {
      foreach (var item in collection)
      {
        
      }
    }

    public Dictionary<Tuple<int, int>, Cell> GetCells()
    {
      return _cells;
    } 

    public Cell GetCell(int xCoord, int yCoord)
    {
      Cell cell;
      _cells.TryGetValue(new Tuple<int, int>(xCoord, yCoord), out cell);
      return cell;
    }

    private void CreateCells()
    {
      for (int i = 0; i < _gUISettings.Width; i++)
        for (int j = 0; j < _gUISettings.Height; j++)
          _cells.Add(
            new Tuple<int, int>(i, j),
            new Cell()
            );
    }
  }

  public class GUISettings
  {
    public int Width { get; set; }
    public int Height { get; set; }
  }
}