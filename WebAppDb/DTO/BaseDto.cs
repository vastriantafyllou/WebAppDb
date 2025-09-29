using System.ComponentModel.DataAnnotations;

namespace WebAppDb.DTO;

public abstract class BaseDto
{
    [Required(ErrorMessage = "The {0} is required")]
    public int Id { get; set; }

    public BaseDto()
    {
        
    }

    public BaseDto(int id)
    {
        Id = id;
    }
    
    // public abstract record BaseDto(
    //     
    //     [property: Required(ErrorMessage = "The {0} is required.")]
    //     int Id
    //     )
    // {
    //     public BaseDto() : this(0)
    //     {
    //         
    //     }
}