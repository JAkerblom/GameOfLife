using System;

namespace GameOfLife.Rules_of_life
{
  internal class AliveCellWithTwoOrThreeNeighborsRule : ILifeRule
  {
    public bool ShouldBeHandled(bool isAlive)
    {
      return isAlive;
    }

    public bool ShouldLive(int nrOfNeighbors)
    {
      return nrOfNeighbors == 2 || nrOfNeighbors == 3;
    }
  }
}