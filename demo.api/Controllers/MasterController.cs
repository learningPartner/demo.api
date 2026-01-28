using demo.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {

        private readonly StudentDbContext _context;

        public MasterController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            try
            {
                var list = _context.CountryMasters.ToList();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getStateByCountryId")]
        public IActionResult GetStateByCountry(int countryId) 
        { 
        
            var list = _context.StateMasters.Where(x=>x.countryId == countryId).ToList();
            return Ok(list);
        }

        [HttpGet("getDistrictByStateId")]
        public async Task<IActionResult>  getDistrictByStateId(int stateId)
        {

            var list = await _context.DistrictMasters.Where(x => x.stateId == stateId).ToListAsync();
            return Ok(list);
        }


    }
}
