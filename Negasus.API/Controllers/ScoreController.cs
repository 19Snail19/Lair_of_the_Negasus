using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Negasus.API.Models;

namespace Negasus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ScoreController : ControllerBase
    {
        private List<HighScore> Score { get; set; } = new List<HighScore>();

        public ScoreController()
        {
            string jsonFile = System.IO.File.ReadAllText("./Resources/BestRun.JSON");
            var scoreData = JsonSerializer.Deserialize<List<HighScore>>(
                jsonFile,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            
            if (scoreData != null)
            {
                Score = scoreData;
            }
        }
    
        [HttpGet]

        public ActionResult<List<HighScore>> GetScore()
        {
            return Ok(Score);
        }
    }
}