using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionThemesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MissionThemesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MissionThemes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionTheme>>> GetMissionThemes()
        {
            return await _context.MissionThemes.ToListAsync();
        }

        // GET: api/MissionThemes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissionTheme>> GetMissionTheme(int id)
        {
            var missionTheme = await _context.MissionThemes.FindAsync(id);

            if (missionTheme == null)
            {
                return NotFound();
            }

            return missionTheme;
        }

        // POST: api/MissionThemes
        [HttpPost]
        public async Task<ActionResult<MissionTheme>> PostMissionTheme(MissionTheme missionTheme)
        {
            _context.MissionThemes.Add(missionTheme);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMissionTheme), new { id = missionTheme.Id }, missionTheme);
        }

        // PUT: api/MissionThemes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissionTheme(int id, MissionTheme missionTheme)
        {
            if (id != missionTheme.Id)
            {
                return BadRequest();
            }

            _context.Entry(missionTheme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionThemeExists(id))
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

        // DELETE: api/MissionThemes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMissionTheme(int id)
        {
            var missionTheme = await _context.MissionThemes.FindAsync(id);
            if (missionTheme == null)
            {
                return NotFound();
            }

            _context.MissionThemes.Remove(missionTheme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissionThemeExists(int id)
        {
            return _context.MissionThemes.Any(e => e.Id == id);
        }
    }

}
