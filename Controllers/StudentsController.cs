using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    //https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetAllStudentsNames()
        { 
            string [] StudentNames=new string[]{"Gaurav","Akshay","Shubham","Mohini","Chaitrali"};

            return Ok(StudentNames);
        }
    }
}
