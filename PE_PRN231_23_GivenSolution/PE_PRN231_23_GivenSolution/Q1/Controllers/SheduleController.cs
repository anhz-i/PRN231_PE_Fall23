using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q1.Models;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheduleController : ControllerBase
    {
        private readonly PE_PRN_Fall2023B1Context _context;
        private IMapper _mapper { get; set; }

        public SheduleController(PE_PRN_Fall2023B1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public IActionResult Add(SheduleDto dto)
        {
            
            if (dto.StartDate > dto.EndDate)
            {
                return BadRequest("StartDate must be smaller than EndDate");
            }
            var checkDup = _context.Schedules.FirstOrDefault(i => i.RoomId == dto.RoomId && i.TimeSlotId == dto.TimeSlotId && i.StartDate == dto.StartDate && i.EndDate == dto.EndDate);
            if (checkDup is not null)
            {
                return StatusCode(406, "Had schedule");
            }
            var schedule = _mapper.Map<Schedule>(dto);
            _context.Add(schedule);
            _context.SaveChanges();
            return Ok();
            
        }
    }
}
