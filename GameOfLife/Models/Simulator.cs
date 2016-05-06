using System;
using System.Collections.Generic;

namespace GameOfLife.Models
{
  public class Simulator
  {
    private GUISettings _gUISettings;
    private Dictionary<Tuple<int, int>, Cell> _cells;

    public Simulator(GUISettings gUISettings)
    {
      _gUISettings = gUISettings;
      _cells = new Dictionary<Tuple<int, int>, Cell>();
      CreateCells();
    }

    public void LetAnEpochPass()
    {
      foreach (var cell in _cells)
      {
        cell.Value.CalculateNextState(CountAliveNeighbors(cell.Key.Item1, cell.Key.Item2));
      }
      foreach (var cell in _cells.Values)
      {
        cell.CommenceNextEpoch();
      }
    }

    public int CountAliveNeighbors(int row, int column)
    {
      var surroundingCellCoordinates = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(row - 1, column - 1),
                new Tuple<int, int>(row - 1, column),
                new Tuple<int, int>(row - 1, column + 1),
                new Tuple<int, int>(row, column + 1),
                new Tuple<int, int>(row + 1, column + 1),
                new Tuple<int, int>(row + 1, column),
                new Tuple<int, int>(row + 1, column - 1),
                new Tuple<int, int>(row, column - 1)
            };
      var livingNeighbors = 0;

      foreach (var coordinate in surroundingCellCoordinates)
        if (_gUISettings.IsValidCoordinate(coordinate.Item1, coordinate.Item2) && this.GetCell(coordinate.Item1, coordinate.Item2).IsAlive())
          livingNeighbors++;

      return livingNeighbors;
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
      for (int i = 1; i <= _gUISettings.Width; i++)
        for (int j = 1; j <= _gUISettings.Height; j++)
          _cells.Add(
            new Tuple<int, int>(i, j),
            new Cell()
            );
    }

    public GUISettings GetGUISettings()
    {
      return _gUISettings;
    }
  }

  public class GUISettings
  {
    public int Width { get; set; }
    public int Height { get; set; }

    public int LowerBoundHorizontal = 1;
    public int LowerBoundVertical = 1;

    public bool IsValidCoordinate(int row, int col)
    {
      return (row >= LowerBoundHorizontal && row <= Width) && (col >= LowerBoundVertical && col <= Height);
    }
  }
}