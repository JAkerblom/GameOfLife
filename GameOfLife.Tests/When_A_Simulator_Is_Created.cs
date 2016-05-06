using NUnit.Framework;
using FluentAssertions;
using System;
using GameOfLife.Models;

namespace GameOfLife.Tests
{
  [TestFixture]
  public class When_a_simulator_is_created
  {
    private Simulator _sim;

    [SetUp]
    public void SetUp()
    {
      GUISettings gs = new GUISettings() { Width = 4, Height = 8 };
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
      _sim.GetCell(xCoord, yCoord).Awake();
      var allCells = _sim.GetCells();
      Cell cell;
      _sim.GetCells().TryGetValue(new Tuple<int, int>(xCoord, yCoord), out cell);
      cell.IsAlive().Should().BeTrue();
      _sim.GetCells().TryGetValue(new Tuple<int, int>(xCoord, yCoord+1), out cell);
      cell.IsAlive().Should().BeFalse();
    }

    [Test]
    [TestCase(2, 3, 3)]
    [TestCase(1, 2, 2)]
    public void It_should_be_able_to_count_cells_living_neighbors(int xCoord, int yCoord, int expectedResult)
    {
      _sim.GetCell(2, 3).Awake();
      _sim.GetCell(2, 4).Awake();
      _sim.GetCell(1, 2).Awake();
      _sim.GetCell(1, 3).Awake();
      _sim.CountAliveNeighbors(xCoord, yCoord).Should().Be(expectedResult);
    }

    [Test]
    [TestCase(1, 3, true)]
    [TestCase(1, 4, true)]
    [TestCase(2, 3, true)]
    [TestCase(2, 4, true)]
    public void It_should_be_able_to_correctly_commence_a_new_epoch(int xCoord, int yCoord, bool expectedResult)
    {
      _sim.GetCell(1, 4).Awake();
      _sim.GetCell(2, 3).Awake();
      _sim.GetCell(2, 4).Awake();

      _sim.LetAnEpochPass();

      _sim.GetCell(xCoord, yCoord).IsAlive().Should().Be(expectedResult);
    }
  }
}
