using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnsekWebApi;
using EnsekWebApi.Data;

namespace EnsekWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReadingsController : ControllerBase
    {
        private readonly DBContext _context;
        // GET: api/MeterReadings
        [HttpGet("meter-reading-uploads")]
        public async Task<ActionResult<IEnumerable<MeterReading>>> GetMeterReadingUploads()
        {
            return await _context.MeterReadings.ToListAsync();
        }
        public MeterReadingsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/MeterReadings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeterReading>>> GetMeterReadings()
        {
            return await _context.MeterReadings.ToListAsync();
        }

        // GET: api/MeterReadings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeterReading>> GetMeterReading(DateTime id)
        {
            var meterReading = await _context.MeterReadings.FindAsync(id);

            if (meterReading == null)
            {
                return NotFound();
            }

            return meterReading;
        }

        // PUT: api/MeterReadings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeterReading(DateTime id, MeterReading meterReading)
        {
            if (id != meterReading.MeterReadingDate)
            {
                return BadRequest();
            }

            _context.Entry(meterReading).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeterReadingExists(id))
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

        // POST: api/MeterReadings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MeterReading>> PostMeterReading(MeterReading meterReading)
        {
            _context.MeterReadings.Add(meterReading);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MeterReadingExists(meterReading.MeterReadingDate))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMeterReading", new { id = meterReading.MeterReadingDate }, meterReading);
        }

        // DELETE: api/MeterReadings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MeterReading>> DeleteMeterReading(DateTime id)
        {
            var meterReading = await _context.MeterReadings.FindAsync(id);
            if (meterReading == null)
            {
                return NotFound();
            }

            _context.MeterReadings.Remove(meterReading);
            await _context.SaveChangesAsync();

            return meterReading;
        }

        private bool MeterReadingExists(DateTime id)
        {
            return _context.MeterReadings.Any(e => e.MeterReadingDate == id);
        }
    }
}
