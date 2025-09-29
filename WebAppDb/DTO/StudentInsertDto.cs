using System.ComponentModel.DataAnnotations;

namespace WebAppDb.DTO
{
    public class StudentInsertDto
    {
        [Required(ErrorMessage = "Firstname is required.")]
        [MinLength(1, ErrorMessage = "Firstname cannot be empty.")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        [MinLength(1, ErrorMessage = "Lastname cannot be empty.")]
        public string? Lastname { get; set; }
        public StudentInsertDto()
        {

        }
        public StudentInsertDto(string? firstname, string? lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }

    //public record StudentInsertDto(
    //    [property: Required(ErrorMessage = "Firstname is required.")]
    //    [property: MinLength(1, ErrorMessage = "Firstname cannot be empty.")]
    //    string? Firstname,

    //    [property: Required(ErrorMessage = "Lastname is required.")]
    //    [property: MinLength(1, ErrorMessage = "Lastname cannot be empty.")]
    //    string? Lastname
    //)
    //{
    //    public StudentInsertDto() : this(string.Empty, string.Empty)
    //    {
    //    }
    //}
}