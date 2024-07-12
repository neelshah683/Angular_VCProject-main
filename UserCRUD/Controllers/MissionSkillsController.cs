using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionSkillsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MissionSkillsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MissionSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionSkill>>> GetMissionSkills()
        {
            return await _context.MissionSkills.ToListAsync();
        }

        // GET: api/MissionSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissionSkill>> GetMissionSkill(int id)
        {
            var missionSkill = await _context.MissionSkills.FindAsync(id);

            if (missionSkill == null)
            {
                return NotFound();
            }

            return missionSkill;
        }

        // POST: api/MissionSkills
        [HttpPost]
        public async Task<ActionResult<MissionSkill>> PostMissionSkill(MissionSkill missionSkill)
        {
            _context.MissionSkills.Add(missionSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMissionSkill), new { id = missionSkill.Id }, missionSkill);
        }

        // PUT: api/MissionSkills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissionSkill(int id, MissionSkill missionSkill)
        {
            if (id != missionSkill.Id)
            {
                return BadRequest();
            }

            _context.Entry(missionSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionSkillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/MissionSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMissionSkill(int id)
        {
            var missionSkill = await _context.MissionSkills.FindAsync(id);
            if (missionSkill == null)
            {
                return NotFound();
            }

            _context.MissionSkills.Remove(missionSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissionSkillExists(int id)
        {
            return _context.MissionSkills.Any(e => e.Id == id);
        }
    }

}
