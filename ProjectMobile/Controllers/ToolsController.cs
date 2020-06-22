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
    public class ToolsController : ControllerBase
    {
        private readonly ProjectMobileContext _context;

        public ToolsController(ProjectMobileContext context)
        {
            _context = context;
        }

        // GET: api/Tools
        [HttpGet]
        public IEnumerable<Tool> GetTool()
        {
            return _context.Tool;
        }

        // GET: api/Tools/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTool([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tool = await _context.Tool.FindAsync(id);

            if (tool == null)
            {
                return NotFound();
            }

            return Ok(tool);
        }

        // PUT: api/Tools/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTool([FromRoute] int id, [FromBody] Tool tool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tool.ToolId)
            {
                return BadRequest();
            }

            _context.Entry(tool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToolExists(id))
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

        // POST: api/Tools
        [HttpPost]
        public async Task<IActionResult> PostTool([FromBody] Tool tool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tool.Add(tool);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ToolExists(tool.ToolId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTool", new { id = tool.ToolId }, tool);
        }

        // DELETE: api/Tools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTool([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tool = await _context.Tool.FindAsync(id);
            if (tool == null)
            {
                return NotFound();
            }

            _context.Tool.Remove(tool);
            await _context.SaveChangesAsync();

            return Ok(tool);
        }

        private bool ToolExists(int id)
        {
            return _context.Tool.Any(e => e.ToolId == id);
        }
    }
}