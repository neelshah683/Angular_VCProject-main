using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissionApi.Data;
using MissionApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MissionApi.Controllers
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

        // GET: api/missionthemes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionTheme>>> GetMissionThemes()
        {
            return await _context.MissionThemes.ToListAsync();
        }

        // GET: api/missionthemes/5
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

        // POST: api/missionthemes
        [HttpPost]
        public async Task<ActionResult<MissionTheme>> PostMissionTheme(MissionTheme missionTheme)
        {
            _context.MissionThemes.Add(missionTheme);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMissionTheme), new { id = missionTheme.id }, missionTheme);
        }

        // PUT: api/missionthemes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissionTheme(int id, MissionTheme missionTheme)
        {
            if (id != missionTheme.id)
            {
                return BadRequest();
            }

            _context.Entry(missionTheme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (!MissionThemeExists(id))
                {
                    return NotFound();
                } else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/missionthemes/5
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
            return _context.MissionThemes.Any(e => e.id == id);
        }
    }
}
