using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppDb.DTO;
using WebAppDb.Models;
using WebAppDb.Services;

namespace WebAppDb.Pages.Students
{
    public class IndexModel : PageModel
    {
        public Error ErrorObj { get; set; } = new();

        private readonly IStudentService studentService;
        public List<StudentReadOnlyDto> StudentsReadOnlyDTO { get; set; } = [];

        public IndexModel(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        public IActionResult OnGet()
        {
            try
            {
                StudentsReadOnlyDTO = studentService.GetAllStudents();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ErrorObj = new Error { Message = ex.Message };

            }
            return Page();
        }
    }
}