using MazeSolverImproved.Entities;
using MazeSolverImproved.Services;
using Microsoft.AspNetCore.Mvc;

namespace MazeSolverImproved.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolutionController : ControllerBase
    {
        private readonly int[,] map = new int[8, 8] {
            {0,1,0,0,0,1,0,0},
            {0,0,0,1,0,1,1,0},
            {1,1,0,1,0,0,0,0},
            {0,0,0,0,0,1,1,0},
            {0,1,1,1,0,1,0,0},
            {0,0,1,1,0,1,1,0},
            {1,0,1,0,0,0,1,0},
            {0,0,0,0,1,0,0,0}
        };

        [HttpGet(Name = "GetSolution")]
        public IActionResult GetSolutionOfMaze()
        {
            var mazeMap = new Map(map);
            var solver = new MazeSolverService(mazeMap);
            solver.Solve();

            return Ok(mazeMap.ToString());
        }
    }
}
