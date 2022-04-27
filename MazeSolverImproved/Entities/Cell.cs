using System.Drawing;

namespace MazeSolverImproved.Entities
{
    public class Cell
    {
        private LinkedList<Cell> adjacents;

        public Cell(Point location)
        {
            adjacents = new LinkedList<Cell>();
            Location = location;
        }

        public LinkedList<Cell> Adjacents { get { return adjacents; } }
        public bool HasBeenVisited { get; set; }
        public int Steps { get; set; }
        public bool IsWall { get; set; }
        public Point Location { get; }

        public void AddAdjacent(Cell adjacentCell)
        {
            adjacents.AddLast(adjacentCell);
        }

        public override string ToString()
        {
            if (IsWall)
                return "#####";

            return "  " + Steps.ToString() + new string(' ', 3 - Steps.ToString().Length);
        }
    }
}
