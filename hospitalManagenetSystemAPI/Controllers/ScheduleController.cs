using hospitalManagenetSystemAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hospitalManagenetSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class ScheduleController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ScheduleController(AppDbContext context)
        {
            this._context = context;
        }


    }
}
