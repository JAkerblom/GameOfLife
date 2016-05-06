using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Tests
{
  [TestFixture]
  public class When_a_game_is_created
  {
    private Simulator _sim;

    [SetUp]
    public void SetUp()
    {
      GUISettings gs = new GUISettings() { Width = 100, Height = 80 };
      _sim = new Simulator(gs);
    }

    [Test]
    public void It_should_contain_only_dead_cells() {
      var cells = _sim.GetCells();
      foreach (var cell in cells)
      {
        cell.Value.IsAlive().Should().BeFalse();
      }
    }

    [Test]
    [TestCase(1, 1, "ToggleLifeStatus")]
    [TestCase(2, 4, "Kill")]
    [TestCase(3, 3, "Awake")]
    public void It_should_be_able_to_manipulate_specific_cells(int xCoord, int yCoord, string fcn)
    {
      bool lifeStatus = _sim.GetCell(xCoord, yCoord).IsAlive();
      bool newLifeStatus;
      switch (fcn)
      {
        case "ToggleLifeStatus":
          newLifeStatus = _sim.GetCell(xCoord, yCoord).ToggleLifeStatus();
          //Assert.AreEqual(!lifeStatus, newLifeStatus);
          newLifeStatus.Should().Be(!lifeStatus);
          break;
        case "Kill":
          newLifeStatus = _sim.GetCell(xCoord, yCoord).Kill();
          //Assert.AreEqual(!lifeStatus, newLifeStatus);
          newLifeStatus.Should().BeFalse();
          break;
        case "Awake":
          newLifeStatus = _sim.GetCell(xCoord, yCoord).Awake();
          newLifeStatus.Should().BeTrue();
          break;
        default:
          break;
      }
    }

    [Test]
    [TestCase(1, 1)]
    public void It_should_be_able_to_correctly_fetch_a_specific_cell(int xCoord, int yCoord)
    {
      //Cell fetchedCell = _sim.GetCell(xCoord, yCoord).Awake();
      _sim.GetCell(xCoord, yCoord).Awake();
      var allCells = _sim.GetCells();
      Cell cell;
      _sim.GetCells().TryGetValue(new Tuple<int, int>(xCoord, yCoord), out cell);
      cell.IsAlive().Should().BeTrue();
      _sim.GetCells().TryGetValue(new Tuple<int, int>(xCoord, yCoord+1), out cell);
      cell.IsAlive().Should().BeFalse();
    }
  }
}
