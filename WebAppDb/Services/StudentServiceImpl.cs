using System.Transactions;
using AutoMapper;
using WebAppDb.DAO;
using WebAppDb.DTO;
using WebAppDb.Exceptions;
using WebAppDb.Models;

namespace WebAppDb.Services;

public class StudentServiceImpl : IStudentService
{
    private readonly IStudentDao studentDao;
    private readonly IMapper mapper;
    private readonly ILogger<StudentServiceImpl> logger;

    public StudentServiceImpl(IStudentDao studentDao, IMapper mapper, ILogger<StudentServiceImpl> logger)   // Dependency Injection
    {
        this.studentDao = studentDao;
        this.mapper = mapper;
        this.logger = logger;
    }

    public StudentReadOnlyDto? InsertStudent(StudentInsertDto studentInsertDto)
    {
        StudentReadOnlyDto studentReadOnlyDto;
        try
        {
            using TransactionScope scope = new TransactionScope();
            Student student = mapper.Map<Student>(studentInsertDto);
            Student? insertedStudent = studentDao.Insert(student);
            studentReadOnlyDto = mapper.Map<StudentReadOnlyDto>(insertedStudent);
            logger.LogInformation("Student {Firstname} {Lastname} inserted successfully",
                studentInsertDto.Firstname, studentInsertDto.Lastname);
            scope.Complete();
            return studentReadOnlyDto;
        }
        catch (TransactionException ex)
        {
            logger.LogError("Student Insertion failed for {Firstname} {Lastname} {ErrorMessage}",
                studentInsertDto.Firstname, studentInsertDto.Lastname, ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            logger.LogError("Student {Firstname} {Lastname} not inserted. {ErrorMessage}",
                studentInsertDto.Firstname, studentInsertDto.Lastname, ex.Message);
            throw;
        }
    }

    public void UpdateStudent(StudentUpdateDto studentUpdateDTO)
    {
        try
        {
            using TransactionScope scope = new TransactionScope();

            if (studentDao.GetById(studentUpdateDTO.Id) == null)
            {
                throw new StudentNotFoundException($"Student with id {studentUpdateDTO.Id} not found.");
            }
            Student student = mapper.Map<Student>(studentUpdateDTO);
            studentDao.Update(student);
            logger.LogInformation("Student {Firstname} {Lastname} updated successfully",
                studentUpdateDTO.FirstName, studentUpdateDTO.LastName);
            scope.Complete();
        }
        catch (StudentNotFoundException ex)
        {
            logger.LogError("Student Update failed for id {Id} {Firstname} {Lastname}. {ErrorMessage}",
                studentUpdateDTO.Id, studentUpdateDTO.FirstName, studentUpdateDTO.LastName, ex.Message);
            throw;
        }
        catch (TransactionException ex)
        {
            logger.LogError("Student Insertion failed for {Firstname} {Lastname}. {ErrorMessage}",
                studentUpdateDTO.FirstName, studentUpdateDTO.LastName, ex.Message);
            throw;
        }
    }

    public void DeleteStudent(int id)
    {
        try
        {
            using TransactionScope scope = new TransactionScope();
            if (studentDao.GetById(id) == null)
            {
                throw new StudentNotFoundException($"Student with id {id} not found.");
            }
            studentDao.Delete(id);
            logger.LogInformation("Student with id {Id} deleted successfully", id);
            scope.Complete();
        }
        catch (TransactionException ex) // auto rollback 
        {
            logger.LogError("Student Deletion failed for id {Id}. {ErrorMessage}",
                id, ex.Message);
            throw;
        }
        catch (StudentNotFoundException ex)
        {
            logger.LogError("Student with id {Id} not found. {ErrorMessage}",
                id, ex.Message);
            throw;
        }
    }

    public StudentReadOnlyDto GetStudent(int id)
    {
        StudentReadOnlyDto studentReadOnlyDTO;
        Student? student;

        try
        {
            student = studentDao.GetById(id);
            if (student == null)
            {
                throw new StudentNotFoundException($"Student with id {id} not found.");
            }
            studentReadOnlyDTO = mapper.Map<StudentReadOnlyDto>(student);
            logger.LogInformation("Student with id {Id} fetched successfully", id);
            return studentReadOnlyDTO;
        }
        catch (StudentNotFoundException ex)
        {
            logger.LogError("Student with id {Id} not found. {ErrorMessage}",
                id, ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            logger.LogError("Error while fetching student with id {Id}. {ErrorMessage}",
                id, ex.Message);
            throw;
        }
    }

    public List<StudentReadOnlyDto> GetAllStudents()
    {
        List<StudentReadOnlyDto> studentReadOnlyDTOs = [];
        StudentReadOnlyDto studentReadOnlyDTO;
        List<Student> students;

        try
        {
            students = studentDao.GetAll();
            foreach (Student student in students)
            {
                studentReadOnlyDTO = mapper.Map<StudentReadOnlyDto>(student);
                studentReadOnlyDTOs.Add(studentReadOnlyDTO);
            }
            logger.LogInformation("All students fetched successfully");
            return studentReadOnlyDTOs;
        }
        catch (Exception ex)
        {
            logger.LogError("Error while fetching all students. {ErrorMessage}",
                ex.Message);
            throw;
        }
    }
}