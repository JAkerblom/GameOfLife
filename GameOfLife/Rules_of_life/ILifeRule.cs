namespace GameOfLife.Rules_of_life
{
  public interface ILifeRule
  {
    bool ShouldBeHandled(bool isAlive);
    bool ShouldLive(int nrOfNeighbors);
  }
}