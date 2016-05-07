using System.Collections.Generic;
using GameOfLife.Rules_of_life;

namespace GameOfLife.Models
{
  public abstract class CellDNA 
  {
    public readonly IEnumerable<ILifeRule> rulesOfLife = new List<ILifeRule>()
    {
      new AliveCellWithFewerThanTwoNeighborsRule(),
      new AliveCellWithMoreThanThreeALiveNeighborsRule(),
      new AliveCellWithTwoOrThreeNeighborsRule(),
      new DeadCellWithThreeAliveNeighborsRule()
    };
  }
}
