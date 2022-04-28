using MazeSolverImproved.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MazeSolverImproved.Tests.Entities
{
    public class MapShould
    {
        private readonly Map map;
        private readonly int[,] arrayMap = new int[,]
        {
            {0, 1, 1},
            {0, 1, 1},
            {0, 1, 1},
        };

        public MapShould()
        {
            map = new Map(arrayMap);
        }

        [Test]
        public void TransformIntegerArrayIntoCellList()
        {
            var expectedCellList = new Dictionary<Point, Cell>()
            {
                {new Point(0,0), new Cell(new Point(0,0)) },
                { new Point(1,0), new Cell(new Point(1,0)) { IsWall = true } },
                { new Point(2,0), new Cell(new Point(2,0)) { IsWall = true } },
                { new Point(0,1), new Cell(new Point(0,1)) },
                {new Point(1,1), new Cell(new Point(1,1)) { IsWall = true } },
                {new Point(2,1), new Cell(new Point(2,1)) { IsWall = true } },
                {new Point(0,2), new Cell(new Point(0,2)) },
                {new Point(1,2), new Cell(new Point(1,2)) { IsWall = true } },
                { new Point(2,2), new Cell(new Point(2,2)) { IsWall = true } },
            };

            var actualCellList = map.Cells;

            CollectionAssert.AreEqual(expectedCellList.Keys, actualCellList.Keys);
            CollectionAssert.AreEqual(expectedCellList.Values, actualCellList.Values);
        }

        [Test]
        public void RelateCellsThatAreNeighboursAndNotWalls()
        {
            var expectedCellsWithNeighbours = new List<Point>()
            {
                new Point(0,0),
                new Point(0,1),
                new Point(0,2)
            };

            var cellsWithNeighbours = map.Cells.Where(x => x.Value.Adjacents.Count > 0);

            Assert.AreEqual(3, cellsWithNeighbours.Count());
            CollectionAssert.AreEqual(expectedCellsWithNeighbours, cellsWithNeighbours.Select(x => x.Key));
        }
    }
}
