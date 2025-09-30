using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppDb.DTO;
using WebAppDb.Models;
using WebAppDb.Services;

namespace WebAppDb.Pages.Students
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public StudentUpdateDto? StudentUpdateDTO { get; set; }
        public List<Error> ErrorArray { get; set; } = [];

        private readonly IStudentService studentService;

        public UpdateModel(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        public IActionResult OnGet(int id)
        {
            try
            {
                StudentReadOnlyDto? studentReadOnlyDTO = studentService.GetStudent(id);
                StudentUpdateDTO = new StudentUpdateDto()
                {
                    Id = studentReadOnlyDTO.Id,
                    FirstName = studentReadOnlyDTO.FirstName,
                    LastName = studentReadOnlyDTO.LastName,
                };

            }
            catch (Exception ex)
            {
                ErrorArray.Add(new Error { Message = ex.Message });
            }
            return Page();
        }

        public void OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                // Handle validation errors
                return;
            }
            try
            {
                StudentUpdateDTO!.Id = id;
                studentService.UpdateStudent(StudentUpdateDTO);
                Response.Redirect("/Students/getall");
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ErrorArray.Add(new Error { Message = ex.Message });
                return;
            }
        }

    }
}