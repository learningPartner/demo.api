using demo.api.interfaces;
using demo.api.Models;
using Microsoft.EntityFrameworkCore;

namespace demo.api.services
{
    public class StudentService:IStudent
    {
        private readonly StudentDbContext _context;

        public StudentService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<StudentMaster> createNewStudent(StudentMaster student)
        {
            _context.StudentMasters.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<List<StudentMaster>> getAllStudents()
        {
            var List = await _context.StudentMasters.ToListAsync();
            return List;
        }
            
        
    }
}
