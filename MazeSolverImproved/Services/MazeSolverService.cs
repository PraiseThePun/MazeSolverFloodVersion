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
            var queue = new Queue<Cell>();
            queue.Enqueue(currentCell);

            while (queue.Count > 0){
                currentCell = queue.Dequeue();
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
            }
        }
    }
}
