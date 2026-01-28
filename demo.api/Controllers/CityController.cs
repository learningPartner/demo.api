using demo.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly StudentDbContext _context;

        public CityController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet("getAllCities")]
        public IActionResult getAllCityList()
        {
            var list = _context.CityMasters.ToList(); 
            return Ok(list);
        }

        [HttpPost("CreateNewCity")]
        public IActionResult AddNewCity(CityMaster obj)
        {
            var isCityExist = _context.CityMasters.SingleOrDefault(x => x.cityName == obj.cityName);
            // select * from tbl whwree cityName= 
            if(isCityExist == null)
            {
                _context.CityMasters.Add(obj);
                _context.SaveChanges();
                return Created("City Created", obj);
            } else
            {
                return BadRequest("City Name Already Exist");
            }
        }



        


    }
}

