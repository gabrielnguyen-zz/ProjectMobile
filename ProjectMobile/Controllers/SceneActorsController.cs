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
    public class SceneActorsController : ControllerBase
    {
        private readonly ProjectMobileContext _context;

        public SceneActorsController(ProjectMobileContext context)
        {
            _context = context;
        }

        // GET: api/SceneActors
        [HttpGet]
        public IEnumerable<SceneActor> GetSceneActor()
        {
            return _context.SceneActor;
        }

        // GET: api/SceneActors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSceneActor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sceneActor = await _context.SceneActor.FindAsync(id);

            if (sceneActor == null)
            {
                return NotFound();
            }

            return Ok(sceneActor);
        }

        // PUT: api/SceneActors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSceneActor([FromRoute] int id, [FromBody] SceneActor sceneActor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sceneActor.SceneId)
            {
                return BadRequest();
            }

            _context.Entry(sceneActor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SceneActorExists(id))
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

        // POST: api/SceneActors
        [HttpPost]
        public async Task<IActionResult> PostSceneActor([FromBody] SceneActor sceneActor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SceneActor.Add(sceneActor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SceneActorExists(sceneActor.SceneId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSceneActor", new { id = sceneActor.SceneId }, sceneActor);
        }

        // DELETE: api/SceneActors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSceneActor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sceneActor = await _context.SceneActor.FindAsync(id);
            if (sceneActor == null)
            {
                return NotFound();
            }

            _context.SceneActor.Remove(sceneActor);
            await _context.SaveChangesAsync();

            return Ok(sceneActor);
        }

        private bool SceneActorExists(int id)
        {
            return _context.SceneActor.Any(e => e.SceneId == id);
        }
    }
}