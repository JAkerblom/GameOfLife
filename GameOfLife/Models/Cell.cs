using System.Linq;

namespace GameOfLife.Models
{
  public class Cell : _Cell
  {
    private bool _lifeStatus;
    private bool _nextLifeStatus;

    public Cell(bool initLifeStatus = false)
    {
      _lifeStatus = initLifeStatus;
    }

    public void CalculateNextState(int nrOfNeighbors)
    {
      var shouldLive = rulesOfLife.Where(it => it.ShouldBeHandled(this.IsAlive())).All(decideIfIt => decideIfIt.ShouldLive(nrOfNeighbors));
      _nextLifeStatus = shouldLive;
    }
    public void CommenceNextEpoch()
    {
      _lifeStatus = _nextLifeStatus;
    }

    public bool IsAlive()
    {
      return _lifeStatus;
    }

    public bool Kill()
    {
      _lifeStatus = false;
      return _lifeStatus;
    }

    public bool Awake()
    {
      _lifeStatus = true;
      return _lifeStatus;
    }

    public bool ToggleLifeStatus()
    {
      _lifeStatus = !_lifeStatus;
      return _lifeStatus;
    }
  }
}
