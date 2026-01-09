using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/attendance")]
    public class AttendanceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }

        // Mark attendance
        [HttpPost]
        public async Task<IActionResult> MarkAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
            return Ok(attendance);
        }

        // Get attendance by employee
        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetByEmployee(int employeeId)
        {
            var records = await _context.Attendances
                .Where(a => a.EmployeeId == employeeId)
                .ToListAsync();

            return Ok(records);
        }
    }
}
