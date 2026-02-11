using demo.api.Models;

namespace demo.api.interfaces
{
    public interface IStudent
    {
        Task<List<StudentMaster>> getAllStudents();
        Task<StudentMaster> createNewStudent(StudentMaster student);
    }
}
