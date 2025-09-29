using WebAppDb.Models;

namespace WebAppDb.DAO;

public interface IStudentDao
{
    Student? Insert(Student student);
    
    void Update(Student student);
    
    void Delete(int id);
    
    Student? GetById(int id);
    
    List<Student> GetAll();
}