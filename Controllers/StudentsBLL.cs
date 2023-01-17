namespace MyWebApi.Controllers;
using BOL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


[ApiController]
[Route("api/[controller]")]
public class StudentsBLL : ControllerBase
{
    private readonly ILogger<StudentsBLL> _logger;

    public StudentsBLL(ILogger<StudentsBLL> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    [EnableCors]
    public IEnumerable<Students> GetAllStudents(){
        List<Students> list=new List<Students>();
        list=StudentDetailsAccess.ShowStudentsDetails();
        return list;
    }
    [HttpGet("{id}")]
    [EnableCors]
    public Students GetStudentById(int id){
        Students student=StudentDetailsAccess.GetStudentById(id);
        return student;
    }
    [HttpDelete("{id}")]
    [EnableCors]
    public void DeleteUserById(int id){
        StudentDetailsAccess.DeleteUserById(id);
    }    
    [HttpPost("student")]
    [EnableCors]
    public void InsertStudent(Students student){
        StudentDetailsAccess.InsertStudent(student);
    }
    [HttpPut("student")]
    [EnableCors]
    public void UpdateDetails(int id, Students student)
    {
        StudentDetailsAccess.Update(student);
    }
}
