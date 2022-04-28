using MazeSolverImproved.Entities;
using MazeSolverImproved.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;

namespace MazeSolverImproved.Tests.Services
{
    public class MazeSolverShould
    {

        [TestCaseSource(nameof(TestCases))]
        public void ChangeTheStepProppertyOfAllCells(int[,] arrayMap, List<Cell> expectedList)
        {
            var map = new Map(arrayMap);
            var solver = new MazeSolverService(map);

            solver.Solve();

            CollectionAssert.AreEqual(expectedList, map.Cells.Values);
        }

        private static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(ArrayMaps[0], ExpectedCellList[0]);
                yield return new TestCaseData(ArrayMaps[1], ExpectedCellList[1]);
                yield return new TestCaseData(ArrayMaps[2], ExpectedCellList[2]);
            }
        }

        private static object[] ArrayMaps
        {
            get
            {
                return new[]
                {
                    new int[,] {
                        { 0, 1 },
                        { 0, 1 } },
                    new int[,] {
                        { 0, 1, 1 },
                        { 0, 1, 1 },
                        { 0, 1, 1 } },
                    new int[,] {
                        { 0, 1, 1 },
                        { 0, 0, 0 },
                        { 1, 1, 0 } },
                };
            }
        }

        private static object[] ExpectedCellList
        {
            get
            {
                return new[]
                {
                    new List<Cell>()
                    {
                        new Cell(new Point(0,0)),
                        new Cell(new Point(1,0)) { IsWall = true },
                        new Cell(new Point(0,1)) { Steps = 1 },
                        new Cell(new Point(1,1)) { IsWall= true },
                    },
                    new List<Cell>()
                    {
                        new Cell(new Point(0,0)),
                        new Cell(new Point(1,0)) { IsWall = true },
                        new Cell(new Point(2,0)) { IsWall = true },
                        new Cell(new Point(0,1)) { Steps = 1 },
                        new Cell(new Point(1,1)) { IsWall = true },
                        new Cell(new Point(2,1)) { IsWall = true },
                        new Cell(new Point(0,2)) { Steps = 2 },
                        new Cell(new Point(1,2)) { IsWall= true },
                        new Cell(new Point(2,2)) { IsWall= true },
                    },
                    new List<Cell>()
                    {
                        new Cell(new Point(0,0)),
                        new Cell(new Point(1,0)) { IsWall = true },
                        new Cell(new Point(2,0)) { IsWall = true },
                        new Cell(new Point(0,1)) { Steps = 1 },
                        new Cell(new Point(1,1)) { Steps = 2 },
                        new Cell(new Point(2,1)) { Steps = 3 },
                        new Cell(new Point(0,2)) { IsWall= true },
                        new Cell(new Point(1,2)) { IsWall= true },
                        new Cell(new Point(2,2)) { Steps = 4 },
                    },
                };
            }
        }
    }
}
