using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMobile.Models;

namespace ProjectMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SceneToolsController : ControllerBase
    {
        private readonly ProjectMobileContext _context;

        public SceneToolsController(ProjectMobileContext context)
        {
            _context = context;
        }

        // GET: api/SceneTools
        [HttpGet]
        public IEnumerable<SceneTool> GetSceneTool()
        {
            return _context.SceneTool;
        }

        // GET: api/SceneTools/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSceneTool([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sceneTool = await _context.SceneTool.FindAsync(id);

            if (sceneTool == null)
            {
                return NotFound();
            }

            return Ok(sceneTool);
        }

        // PUT: api/SceneTools/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSceneTool([FromRoute] int id, [FromBody] SceneTool sceneTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sceneTool.SceneId)
            {
                return BadRequest();
            }

            _context.Entry(sceneTool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SceneToolExists(id))
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

        // POST: api/SceneTools
        [HttpPost]
        public async Task<IActionResult> PostSceneTool([FromBody] SceneTool sceneTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SceneTool.Add(sceneTool);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SceneToolExists(sceneTool.SceneId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSceneTool", new { id = sceneTool.SceneId }, sceneTool);
        }

        // DELETE: api/SceneTools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSceneTool([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sceneTool = await _context.SceneTool.FindAsync(id);
            if (sceneTool == null)
            {
                return NotFound();
            }

            _context.SceneTool.Remove(sceneTool);
            await _context.SaveChangesAsync();

            return Ok(sceneTool);
        }

        private bool SceneToolExists(int id)
        {
            return _context.SceneTool.Any(e => e.SceneId == id);
        }
    }
}