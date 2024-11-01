using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JpStudentAndCourse.Models;
using JpStudentAndCourse.Contracts;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IStudentService _studentService;
    private readonly ICourseService _courseService;

    public List<Student> Students { get; set; } = new List<Student>();
    public List<Course> Courses { get; set; } = new List<Course>();

    public IndexModel(ILogger<IndexModel> logger, IStudentService studentService, ICourseService courseService)
    {
        _logger = logger;
        _studentService = studentService;
        _courseService = courseService;
    }

    public async Task OnGetAsync()
    {
        Students = (await _studentService.GetAllAsync()).ToList();
        Courses = (await _courseService.GetAllAsync()).ToList();
    }
}
