using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballAcademyAPI.Data;
using FootballAcademyAPI.Models;
using System.Threading.Tasks;


namespace FootballAcademyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController(FootballAcademyDbContext context) : ControllerBase
    {
        // GET: api/players
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await context.Players.ToListAsync();
            return Ok(players);
        }

        // GET: api/players/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await context.Players.FindAsync(id);
            if (player == null)
                return NotFound();

            return Ok(player);
        }

        // POST: api/players
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Player player)
        {
            context.Players.Add(player);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = player.PlayerId }, player);
        }

        // PUT: api/players/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Player updated)
        {
            var player = await context.Players.FindAsync(id);
            if (player == null)
                return NotFound();

            player.FullName = updated.FullName;
            player.PhoneNumber = updated.PhoneNumber;
            player.DateOfBirth = updated.DateOfBirth;
            player.Gender = updated.Gender;
            player.JoinDate = updated.JoinDate;
            player.Status = updated.Status;
            player.ImageUrl = updated.ImageUrl;

            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/players/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var player = await context.Players.FindAsync(id);
            if (player == null)
                return NotFound();

            context.Players.Remove(player);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
