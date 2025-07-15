using System.Threading.Tasks;
using FootballAcademyAPI.Data;
using FootballAcademyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballAcademyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionsController(FootballAcademyDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subs = await context.Subscriptions.Include(s => s.Player).ToListAsync();
            return Ok(subs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sub = await context.Subscriptions.Include(s => s.Player).FirstOrDefaultAsync(s => s.SubscriptionId == id);
            if (sub == null) return NotFound();
            return Ok(sub);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Subscription sub)
        {
            context.Subscriptions.Add(sub);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = sub.SubscriptionId }, sub);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Subscription updated)
        {
            var sub = await context.Subscriptions.FindAsync(id);
            if (sub == null) return NotFound();

            sub.Type = updated.Type;
            sub.Amount = updated.Amount;
            sub.StartDate = updated.StartDate;
            sub.EndDate = updated.EndDate;
            sub.Notes = updated.Notes;
            sub.PlayerId = updated.PlayerId;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sub = await context.Subscriptions.FindAsync(id);
            if (sub == null) return NotFound();

            context.Subscriptions.Remove(sub);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
