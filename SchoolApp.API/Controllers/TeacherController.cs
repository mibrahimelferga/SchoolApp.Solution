using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Repositories;
using SchoolApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IGenericRepository<Teacher> _teacherRepo;

        public TeacherController(IGenericRepository<Teacher> teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            try
            {
                var teachers = await _teacherRepo.GetAllAsync();
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{TeacherId}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int TeacherId)
        {
            try
            {
                var teacher = await _teacherRepo.GetByIdAsync(TeacherId);
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]

        public async Task<ActionResult<Teacher>> AddTeacher(Teacher teacher)
        {
            try
            {
                var add = await _teacherRepo.Add(teacher);
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{TeacherId}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(int TeacherId)
        {
            var teacher = await _teacherRepo.GetByIdAsync(TeacherId);
            if (teacher == null)
                return BadRequest();
            try
            {
                var delete = await _teacherRepo.Delete(teacher);
                return Ok(true);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        public async Task<ActionResult<Teacher>> UpdateTeacher(Teacher teacher)
        {
            try
            {
                var update = await _teacherRepo.Update(teacher);
                return Ok(teacher);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}
