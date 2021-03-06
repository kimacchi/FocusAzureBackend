#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FocusApi.Models;

namespace FocusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly ActivityContext _context;

        public ActivitiesController(ActivityContext context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivity(int id)
        {
            var activity = await _context.Activities.Where(ele => ele.userId.Equals(id)).ToListAsync();
            
            if (activity == null)
            {
                return NoContent();
            }

            return activity;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivity(int id, Activity activity)
        {
            if (id != activity.activityId)
            {
                return BadRequest();
            }

            _context.Entry(activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchActivity(int id, [FromBody] JsonPatchDocument<Activity> patchEntity)
        {
            var entity = await _context.Activities.FindAsync(id);
            if(entity == null){
                return NotFound();
            }
            patchEntity.ApplyTo(entity, ModelState);

            return Ok(entity);
        }

        // POST: api/Activities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Activity>> PostActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivity", new { id = activity.activityId }, activity);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        private bool ActivityExists(int id)
        {
            return _context.Activities.Any(e => e.activityId == id);
        }
    }
}
