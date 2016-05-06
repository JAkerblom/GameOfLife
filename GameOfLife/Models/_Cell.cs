using System.Collections.Generic;
using GameOfLife.Rules_of_life;

namespace GameOfLife.Models
{
  public abstract class _Cell 
  {
    public readonly IEnumerable<ILifeRule> rulesOfLife = new List<ILifeRule>()
    {
      new ALiveCellWithFewerThanTwoNeighborsRule(),
      new AliveCellWithMoreThanThreeALiveNeighborsRule(),
      new AliveCellWithTwoOrThreeNeighborsRule(),
      new DeadCellWithThreeAliveNeighborsRule()
    };
  }
}
