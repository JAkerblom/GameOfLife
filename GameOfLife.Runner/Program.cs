using System;
using GameOfLife.Models;

namespace GameOfLife.Runner
{
  public class Program
  {
    static void Main(string[] args)
    {
      GUISettings gs = new GUISettings() { Width = 20, Height = 16 };
      Simulator sim = new Simulator(gs);
      
      Console.WriteLine("Choose your first option:");
      Console.WriteLine("1. Start with default life initialization setup");
      Console.WriteLine("2. Type in your own initialization coordinates");
      Console.WriteLine("3. Start with empty life canvas and manually touch the life of cells");
      string start = Console.ReadLine();

      switch (start)
      {
        case "1":
          //sim.GetCell(1, 4).Awake();
          //sim.GetCell(2, 3).Awake();
          //sim.GetCell(2, 4).Awake();
          sim.GetCell(5, 5).Awake();
          sim.GetCell(5, 6).Awake();
          sim.GetCell(5, 7).Awake();

          break;
        case "2":
          Console.WriteLine(" Feed the application with coordinates.");
          Console.WriteLine(" Type 'x,y' where x and y are width and height coordinates less than " + gs.Width + " and " + gs.Height + ".");
          break;
        case "3":
        default:
          Console.WriteLine("You entered a faulty command! Exiting");
          break;
      }

      OutputBoard(sim);
      sim.LetAnEpochPass();
      OutputBoard(sim);
      sim.LetAnEpochPass();
      OutputBoard(sim);

      Console.ReadLine();
    }

    private static void OutputBoard(Simulator sim)
    {
      var line = new String('-', sim.GetGUISettings().Width);
      Console.WriteLine(line);

      for (int y = sim.GetGUISettings().LowerBoundVertical; y <= sim.GetGUISettings().Height; y++)
      {
        for (int x = sim.GetGUISettings().LowerBoundHorizontal; x <= sim.GetGUISettings().Width; x++)
        {
          Console.Write(sim.GetCell(x, y).IsAlive() ? "1" : "0");
        }

        Console.WriteLine();
      }
    }
  }
}
