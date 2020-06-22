using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMobile.Models;

namespace ProjectMobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenesController : ControllerBase
    {
        private readonly ProjectMobileContext _context;

        public ScenesController(ProjectMobileContext context)
        {
            _context = context;
        }

        // GET: api/Scenes
        [HttpGet]
        public async Task<IEnumerable<Scene>> GetSceneAsync()
        {
            return await _context.Scene
                .Include(scene=> scene.SceneActor)
                .Include(scene=> scene.SceneTool)
                .ToListAsync();
        }

        // GET: api/Scenes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScene([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scene = await _context.Scene.FindAsync(id);

            if (scene == null)
            {
                return NotFound();
            }

            return Ok(scene);
        }

        // PUT: api/Scenes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScene([FromRoute] int id, [FromBody] Scene scene)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scene.SceneId)
            {
                return BadRequest();
            }

            _context.Entry(scene).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SceneExists(id))
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

        // POST: api/Scenes
        [HttpPost]
        public async Task<IActionResult> PostScene([FromBody] Scene scene)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Scene.Add(scene);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScene", new { id = scene.SceneId }, scene);
        }

        // DELETE: api/Scenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScene([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scene = await _context.Scene.FindAsync(id);
            if (scene == null)
            {
                return NotFound();
            }

            _context.Scene.Remove(scene);
            await _context.SaveChangesAsync();

            return Ok(scene);
        }

        private bool SceneExists(int id)
        {
            return _context.Scene.Any(e => e.SceneId == id);
        }
    }
}