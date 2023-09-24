using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Logging;
using School.BLL.Repositories;
using SchoolApp.DAL.Data;
using SchoolApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IGenericRepository<Student> _studentRepo;
        // private readonly IStudentRepository _stRepo;

        public StudentController(IGenericRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo;
            // _stRepo = stRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            try {
                var students = await _studentRepo.GetAllAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{StudentId}")]
        public async Task<ActionResult<Student>> GetStudent(int StudentId)
        {
            try
            {

                var student = await _studentRepo.GetByIdAsync(StudentId);
                return Ok(student);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            try
            {
                var add = await _studentRepo.Add(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{StudentId}")]
        public async Task<ActionResult<Student>> DeleteStudent(int StudentId)
        {
            var student = await _studentRepo.GetByIdAsync(StudentId);
            if (student == null)
                return BadRequest();

            try
            {

                var delete = await _studentRepo.Delete(student);
                return Ok("Delete Successful");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(Student student)
        {
            try
            {

                var update = await _studentRepo.Update(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Class/{ClassId}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentByClassNumber(int ClassId)
        {
            try
            {
                var studentsClass = await _studentRepo.GetStudentByClassId(ClassId);
                return Ok(studentsClass);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);

            }

        }

        [HttpPut("AddStudentToClass")]
        public async Task<ActionResult<Student>> AddStudentListToClass(int[] StudentsId, int ClassId)
        {
             
            try
            {

                var addStudent = await _studentRepo.AddStudentListToClass(StudentsId,ClassId);
                return Ok("Add Successful");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RemoveStudentFromClass")]
        public async Task<ActionResult<Student>> RemoveStudentListToClass(int[] StudentsId, int? ClassId)
        {
            try
            {

                var addStudent = await _studentRepo.RemoveStudentListToClass(StudentsId, ClassId);
                return Ok("Remove Successful");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }
        }


    }
}
