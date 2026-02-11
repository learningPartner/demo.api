using demo.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly StudentDbContext _context;
        private readonly string _targetFolder = Path.Combine(Directory.GetCurrentDirectory(), "photos");

        public EmployeeController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpPost("CreateEmployee")]
        public IActionResult CreateNewEMp(EmployeeViewModel obj)
        {
            Logger.Log("CreateEmployee Startes");
            EmployeeBasic basicOnj = new EmployeeBasic()
            {
                empName = obj.empName,
                empEmail = obj.empEmail,
                empMobile = obj.empMobile
            };
            var strObj = basicOnj.ToString();
            Logger.Log("CreateEmployee EmployeeBasic Obj Created -" + strObj);
            _context.EmployeeBasics.Add(basicOnj);
            _context.SaveChanges();
            Logger.Log("CreateEmployee EmployeeBasic Obj Stored");
           
            EmployeeBank bankObj = new EmployeeBank()
            {
                empId = basicOnj.empId,
                bankName = obj.bankName,
                accNo = obj.accNo,
                IfscCode = obj.IfscCode
            };
            Logger.Log("CreateEmployee EmployeeBank Obj Created");
            _context.EmployeeBanks.Add(bankObj);
            _context.SaveChanges();
            Logger.Log("CreateEmployee EmployeeBank Obj Stored");
            return Created("Emp Created Succes", basicOnj);

        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            if (!Directory.Exists(_targetFolder))
                Directory.CreateDirectory(_targetFolder);
            var newfileName = file.FileName.Substring(0, 3) +  DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_targetFolder, newfileName);

            if (System.IO.File.Exists(filePath))
                return Conflict("A file with the same name already exists.");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { file.FileName, file.Length });
        }
        //loggeer 


    }
}
