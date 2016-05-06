using FluentAssertions;
using NUnit.Framework;
using GameOfLife.Models;

namespace GameOfLife.Tests
{
  [TestFixture]
  class When_A_Cell_Is_Created
  {
    [Test]
    [TestCase(true, 4, false)]
    [TestCase(true, 1, false)]
    [TestCase(true, 2, true)]
    [TestCase(false, 3, true)]
    public void It_should_follow_all_rules_of_life(bool isAlive, int nrOfNeighbors, bool expectedLifeStatusAfterEpoch)
    {
      Cell cell = new Cell(isAlive);
      cell.CalculateNextState(nrOfNeighbors);
      cell.CommenceNextEpoch();
      cell.IsAlive().Should().Be(expectedLifeStatusAfterEpoch);
    }
  }
}
