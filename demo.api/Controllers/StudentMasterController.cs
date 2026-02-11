using demo.api.Models;
using demo.api.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentMasterController : ControllerBase
    {
        private readonly StudentDbContext _context;

       private readonly StudentService _studentService; 

        public StudentMasterController(StudentDbContext context, StudentService studentService)
        {
            _context = context;
            _studentService = studentService;
        }


        //[HttpGet("getAllStudentMasterData")]
        //public List<StudentMaster> getAllStudentMasterData()
        //{
        //    var list = _context.StudentMasters.ToList();
        //    return list;
        //}

        [HttpGet("getAllStudentMasterData")]
        public async Task<List<StudentMaster>> getAllStudentMasterData()
        {
             
            var list = await _studentService.getAllStudents();
            return list;
        }


        [HttpGet("getStudentDropdwonData")]
        public List<StudentDropdownModel> getStudentDropdwonData()
        {
            var list = _context.StudentMasters.ToList();

            List<StudentDropdownModel> dropdownList = new List<StudentDropdownModel>();

            for (int i = 0; i < list.Count; i++)
            {
                StudentDropdownModel obj = new StudentDropdownModel()
                {
                    studId = list[i].studId,
                    studName = list[i].studName
                };
                dropdownList.Add(obj);
            }

            //foreach (var item in list)
            //{
            //    StudentDropdownModel obj = new StudentDropdownModel()
            //    {
            //        studId = item.studId,
            //        studName = item.studName
            //    };
            //    dropdownList.Add(obj);
            //}

            return dropdownList;
        }

        [HttpGet("GetStudents")]
        public async Task<List<StudentMaster>> getStudents()
        {
            var list = await _context.StudentMasters.ToListAsync();
            return list;

        }


        [HttpGet("getAllCities")]
        public List<CityMaster> getAllCities()
        {
            var list = _context.CityMasters.ToList();
            //select * from  cityMasterTbl
            return list;
        }
        [HttpPost("CreateStudent")]
        public async Task <StudentMaster> CreateNewStudent(StudentMaster obj)
        {
            var isExist = _context.StudentMasters.SingleOrDefault(m => m.userName == obj.userName);
            if(isExist != null)
            {
                throw new Exception("UserName Already Exist");
            } else
            {
                _context.StudentMasters.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
           
        }

        [HttpPost("login")]
        public IActionResult LoginStudent(StudentLoginModel obj)
        {
            var isUserPresent = _context.StudentMasters.SingleOrDefault(x => x.userName == obj.userName && x.password == obj.password);
            if(isUserPresent != null)
            {
                LoginReturnModel loginData = new LoginReturnModel()
                {
                    email = isUserPresent.email,
                    mobile = isUserPresent.mobile,
                    studId = isUserPresent.studId,
                    studName = isUserPresent.studName
                };

                LoginReturnModel loginmodel2  = new LoginReturnModel();
                loginmodel2.mobile = isUserPresent.mobile;
                loginmodel2.email   = isUserPresent.email;
                loginmodel2.studId  = isUserPresent.studId;
                loginmodel2.studName= isUserPresent.studName;

                return StatusCode(200, loginData);
            } else
            {
                return StatusCode(401, "Invalid Credentials");
            }

        }

        [HttpGet("checkIfPanCardExit")]
        public IActionResult isPnExist(string pancard)
        {
            try
            {
                // var isExit = _context.StudentMasters.SingleOrDefault(m => m.pancard == pancard);
                var isExit = _context.StudentMasters.FirstOrDefault(m => m.pancard == pancard);
                if (isExit != null)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound("No Existinf Record Found");

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
           
        }

        [HttpGet("getStudentsWithStartChar")]
        public IActionResult getStudentsWithStartChar(string startChar)
        {
            try
            {
                var list = _context.StudentMasters.Where(m => m.studName.StartsWith(startChar));
                var containList = _context.StudentMasters.Where(m => m.studName.Contains(startChar));
                var endingwith = _context.StudentMasters.Where(m => m.studName.EndsWith(startChar));

                return StatusCode(200, list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                //logger 
            }
        }

        [HttpGet("getActiveStudents")]
        public IActionResult getAllActiveStudents()
        {
            try
            {
                var list = _context.StudentMasters.Where(m => m.isActive == true);
                return StatusCode(200,list);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                //logger 
            }
        }

        [HttpPost("CreateNewCity")]
        public CityMaster addNewCity(CityMaster obj)
        {
            _context.CityMasters.Add(obj);
            //insert into cityMasterTbl values(...)
            _context.SaveChanges();
            return obj;
        }

        [HttpPut("UpdateStudent")]
        public StudentMaster UpdateStud(StudentMaster obj,int studid)
        {
            if(studid ==  obj.studId)
            {
                var student = _context.StudentMasters.SingleOrDefault(m => m.studId == studid);
                if (student != null)
                {
                    student.email = obj.email;
                    student.studName = obj.studName;
                    student.pancard = obj.pancard;
                    _context.SaveChanges();
                }
            }
            
            return obj; 
        }

        [HttpDelete("DeleteStudentById")]
        public bool DeleteStud(int id)
        {
            var stud = _context.StudentMasters.FirstOrDefault(m=> m.studId == id);
            if(stud != null)
            {
                _context.StudentMasters.Remove(stud);
                _context.SaveChanges();
                return true;
            } else
            {
                return false; 
            
            }

        }

        //[HttpGet("getStudents")]
        //public List<Student> getAllStudents()
        //{
        //    List<Student> studentList = new List<Student>();

        //    Student stud1 = new Student()
        //    {
        //        isActive= true,
        //        mobileNo="9988776655",
        //        startDate = DateTime.Now,
        //        studId =1
        //    };
        //    studentList.Add(stud1);

        //    Student stud2 = new Student()
        //    {
        //        isActive = true,
        //        mobileNo = "88778877",
        //        startDate = DateTime.Now,
        //        studId = 2
        //    };
        //    studentList.Add(stud2);

        //    return studentList; 
        //}

    }

}
