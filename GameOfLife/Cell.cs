using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
  public class Cell
  {
    private bool _lifeStatus;

    public Cell(bool initLifeStatus = false)
    {
      _lifeStatus = initLifeStatus;
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
