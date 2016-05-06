using System;
using System.Collections;
using System.Collections.Generic;
using GameOfLife;

namespace GameOfLife.Runner
{
  public class Program
  {
    static void Main(string[] args)
    {
      GUISettings gs = new GUISettings() { Width = 100, Height = 80 };
      Simulator s = new Simulator(gs);
      
      Console.WriteLine("Choose your first option:");
      Console.WriteLine("1. Start with default life initialization setup");
      Console.WriteLine("2. Type in your own initialization coordinates");
      Console.WriteLine("3. Start with empty life canvas and manually touch the life of cells");
      string start = Console.ReadLine();

      switch (start)
      {
        case "1":
          s.ToggleCell(5, 5);
          s.ToggleCell(5, 6);
          s.ToggleCell(5, 7);
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
    }
  }
}
