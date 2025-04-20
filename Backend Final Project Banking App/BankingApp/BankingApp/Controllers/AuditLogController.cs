using BankingApp.Database;
using BankingApp.Model.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuditLogController : ControllerBase
    {
        private readonly MyContext _context;

        public AuditLogController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("all-logs")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllLogs()
        {
            var logs = await _context.AuditLogs
                .OrderByDescending(log => log.Time)
                .ToListAsync();

            return Ok(logs);
        }

        [HttpGet("by-user/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetLogsByUser(string userId)
        {
            var logs = await _context.AuditLogs
                .Where(log => log.UserId == userId)
                .OrderByDescending(log => log.Time)
                .ToListAsync();

            return Ok(logs);
        }

        [HttpGet("by-date")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetLogsByDate([FromQuery] DateTime date)
        {
            var logs = await _context.AuditLogs
                .Where(log => log.Time.Date == date.Date)
                .OrderByDescending(log => log.Time)
                .ToListAsync();

            return Ok(logs);
        }
    }
}
