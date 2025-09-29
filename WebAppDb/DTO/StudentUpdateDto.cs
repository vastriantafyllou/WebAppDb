using System.ComponentModel.DataAnnotations;

namespace WebAppDb.DTO;

public class StudentUpdateDto : BaseDto
{
    [Required(ErrorMessage = "Firstname is required")] 
    [MinLength(1, ErrorMessage = "Firstname cannot be empty")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Lastname is required")]
    [MinLength(1, ErrorMessage = "Lastname cannot be empty")]
    public string? LastName { get; set; }

    public StudentUpdateDto()
    {

    }

    public StudentUpdateDto(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    //public record StudentUpdateDto(

    //    int Id,

    //    [property: Required(ErrorMessage = "Firstname is required.")]
    //    [property: MinLength(1, ErrorMessage = "Firstname cannot be empty.")]
    //    string? Firstname,

    //    [property: Required(ErrorMessage = "Lastname is required.")]
    //    [property: MinLength(1, ErrorMessage = "Lastname cannot be empty.")]
    //    string? Lastname
    //) : BaseDto(Id)
    //{
    //    public StudentUpdateDto() : this(0, string.Empty, string.Empty)
    //    {
    //    }
    //}
}
