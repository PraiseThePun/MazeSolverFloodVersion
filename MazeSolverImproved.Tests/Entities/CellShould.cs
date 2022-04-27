using MazeSolverImproved.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;

namespace MazeSolverImproved.Tests.Entities
{
    public class CellShould
    {
        [TestCaseSource(nameof(CellsWithDifferentToStrings))]
        public void PrintNumberOfStepsOrWallChars(Cell cell, string expected)
        {
            Assert.AreEqual(expected, cell.ToString());
        }

        public static IEnumerable<TestCaseData> CellsWithDifferentToStrings
        {
            get
            {
                yield return new TestCaseData(new object[] { new Cell(new Point(0, 0)) { Steps = 1 }, "  1  " });
                yield return new TestCaseData(new object[] { new Cell(new Point(0, 0)) { Steps = 10 }, "  10 " });
                yield return new TestCaseData(new object[] { new Cell(new Point(0, 0)) { IsWall = true }, "#####" });
            }
        }
    }
}
