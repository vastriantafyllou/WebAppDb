using WebAppDb.DTO;

namespace WebAppDb.Services;

public interface IStudentService
{
    StudentReadOnlyDto? InsertStudent(StudentInsertDto studentInsertDto);
    void UpdateStudent(StudentUpdateDto studentUpdateDto);
    void DeleteStudent(int id);
    StudentReadOnlyDto GetStudent(int id);
    List<StudentReadOnlyDto> GetAllStudents();
}