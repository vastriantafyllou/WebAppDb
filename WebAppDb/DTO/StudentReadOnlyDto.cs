using System.ComponentModel.DataAnnotations;

namespace WebAppDb.DTO;

public class StudentReadOnlyDto : BaseDto
{
    [Required(ErrorMessage = "Firstname is required")]
    [MinLength(1, ErrorMessage = "Firstname cannot be empty")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Lastname is required")]
    [MinLength(1, ErrorMessage = "Lastname cannot be empty")]
    public string? LastName { get; set; }

    public StudentReadOnlyDto()
    {

    }

    public StudentReadOnlyDto(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    //public record StudentReadOnlyDto(
    //    int Id,
    //    string? Firstname,
    //    string? Lastname
    //) : BaseDto(Id)
    //{
    //    public StudentReadOnlyDto() : this(0, string.Empty, string.Empty)
    //    {
    //    }
    //}
}