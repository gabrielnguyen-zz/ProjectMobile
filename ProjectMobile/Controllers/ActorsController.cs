using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMobile.Models;
using ProjectMobile.VModel;

namespace ProjectMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ProjectMobileContext _context;

        public ActorsController(ProjectMobileContext context)
        {
            _context = context;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<IEnumerable<Actor>> GetActorAsync()
        {
            return await _context.Actor
                .Include(actor=>actor.Account)
                .Include(actor=>actor.SceneActor)
                .ToListAsync();
        }
        // GET: api/Actors/accountID/1
        // /api/Actors/accountID/nguyen
        [HttpGet("accountId/{id}")]
        public async Task<IActionResult> GetActorByAccountId([FromBody] string id)
        {
            var actor = _context.Actor.Where(record => record.AccountId == id).FirstOrDefault();

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actor = await _context.Actor.FindAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        // PUT: api/Actors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor([FromRoute] int id, [FromBody] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actor.ActorId)
            {
                return BadRequest();
            }

            _context.Entry(actor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(id))
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

        // POST: api/Actors
        [HttpPost]
        public async Task<IActionResult> PostActor([FromBody] ActorVModel actorvmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Account account = new Account();
            account.AccountId = actorvmodel.AccountId;
            account.Password = actorvmodel.password;
            account.Role = "user";
            _context.Account.Add(account);
            await _context.SaveChangesAsync();
            Actor actor = new Actor();
            actor.ActorName = actorvmodel.ActorName;
            actor.ActorDes = actorvmodel.ActorDes;
            actor.Phone = actorvmodel.Phone;
            actor.Email = actorvmodel.Email;
            actor.CreatedBy = actorvmodel.CreatedBy;
            actor.UpdatedBy = actorvmodel.UpdatedBy;
            actor.AccountId = actorvmodel.AccountId;
            _context.Actor.Add(actor);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetActor", new { id = actor.ActorId }, actor);
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actor = await _context.Actor.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }

            _context.Actor.Remove(actor);
            await _context.SaveChangesAsync();

            return Ok(actor);
        }

        private bool ActorExists(int id)
        {
            return _context.Actor.Any(e => e.ActorId == id);
        }
    }
}