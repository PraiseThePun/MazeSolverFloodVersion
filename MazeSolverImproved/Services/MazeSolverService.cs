using MazeSolverImproved.Entities;

namespace MazeSolverImproved.Services
{
    public class MazeSolverService
    {
        private readonly Map map;

        public MazeSolverService(Map map)
        {
            this.map = map;
        }

        public void Solve()
        {
            var startCell = map.Cells.First().Value;
            var currentCell = startCell;
            var endCell = map.Cells.Last().Value;
            var queue = new Queue<Cell>();

            while (currentCell != endCell){
                var adjacents = currentCell.Adjacents;

                foreach (var cell in adjacents)
                {
                    if (!cell.HasBeenVisited)
                    {
                        queue.Enqueue(cell);
                        currentCell.HasBeenVisited = true;
                        cell.Steps = currentCell.Steps + 1;
                    }
                }

                currentCell = queue.Dequeue();
            }
        }
    }
}
