using System.Drawing;

namespace MazeSolverImproved.Entities
{
    public class Map
    {
        private readonly Dictionary<Point, Cell> cells;
        private readonly int[,] arrayMap;

        public Map(int[,] arrayMap)
        {
            cells = new Dictionary<Point, Cell>();
            this.arrayMap = arrayMap;
            InitializeCellsGrid();
        }

        public Dictionary<Point, Cell> Cells { get => cells; }

        private void AddRelation(Point cellPointA, Point cellPointB)
        {
            if (!cells[cellPointA].IsWall &&
                !cells[cellPointB].IsWall)
            {
                var cellA = cells[cellPointA];
                var cellB = cells[cellPointB];

                cellA.AddAdjacent(cellB);
                cellB.AddAdjacent(cellA);
            }
        }

        private void InitializeCellsGrid()
        {
            for (int i = 0; i < arrayMap.GetLength(0); i++)
            {
                for (int j = 0; j < arrayMap.GetLength(1); j++)
                {
                    var location = new Point(j, i);
                    var cell = new Cell(location);

                    if (arrayMap[i,j] == 1)
                        cell.IsWall = true;

                    cells.Add(location, cell);
                    InitializeCellRelationships(location);
                }
            }
        }

        private void InitializeCellRelationships(Point currentPoint)
        {
            var northPoint = new Point(currentPoint.X, currentPoint.Y - 1);
            var westPoint = new Point(currentPoint.X - 1, currentPoint.Y);

            TrySetNorthRelationShip(currentPoint, northPoint);
            TrySetWestRelationShip(currentPoint, westPoint);
        }

        private void TrySetNorthRelationShip(Point currentCell, Point northCell)
        {
            try
            {
                AddRelation(currentCell, northCell);
            }
            catch (KeyNotFoundException)
            {
            }
        }   
        
        private void TrySetWestRelationShip(Point currentCell, Point westCell)
        {
            try
            {
                AddRelation(currentCell, westCell);
            }
            catch (KeyNotFoundException)
            {
            }
        }

        public override string ToString()
        {
            const string LETTERS = "\t A    B    C    D    E    F    G    H";
            const string BLOCK = "###";

            var border = "  | " + new string('#', 46);
            var line = "  +" + new string('-', 46);

            var strMaze = LETTERS + "\n" + line + "\n" + border + "\n";

            for (int i = 0; i < arrayMap.GetLength(0); i++)
            {
                strMaze += " " + (i + 1) + "| " + BLOCK;

                for (int j = 0; j < arrayMap.GetLength(1); j++)
                {
                    strMaze += cells[new Point(j,i)].ToString();
                }

                strMaze += BLOCK + "\n";
            }

            return strMaze + border;
        }
    }
}
