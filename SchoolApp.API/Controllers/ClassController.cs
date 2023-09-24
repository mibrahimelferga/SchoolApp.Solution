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
    public class ClassController : ControllerBase
    {
        private readonly IGenericRepository<Class> _classRepo;
        public ClassController(IGenericRepository<Class> classRepo)
        {
            _classRepo = classRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            try
            {
                var classes = await _classRepo.GetAllAsync();
                return Ok(classes);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{ClassId}")]
        public async Task<ActionResult<Class>> GetClass(int ClassId)
        {
            try
            {
                var classrom = await _classRepo.GetByIdAsync(ClassId);
                return Ok(classrom);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]

        public async Task<ActionResult<Class>> AddClass(Class classroom)
        {
            try
            {
                var add = await _classRepo.Add(classroom);
                return Ok(classroom+"Add Successful");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{ClassId}")]
        public async Task<ActionResult<Class>> DeleteClass(int ClassId)
        {
            var classroom = await _classRepo.GetByIdAsync(ClassId);

            if (classroom == null)
                return BadRequest("");
            try
            {
                var delete = await _classRepo.Delete(classroom);
                return Ok(true);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public async Task<ActionResult<Class>> UpdateClass(Class classroom)
        {
            try
            {
                var update = await _classRepo.Update(classroom);
                return Ok(classroom);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("AssignTeacherToClass")]
        public async Task<ActionResult<Class>> AssignTeacherToClass(int TeacherId, int ClassId)
        {
            try
            {

                var addStudent = await _classRepo.AssignTeacherToClass(TeacherId, ClassId);
                return Ok("Assign Successful");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UnAssignTeacherToClass")]
        public async Task<ActionResult<Class>> UnAssignTeacherToClass(int? TeacherId, int ClassId)
        {
            try
            {

                var addStudent = await _classRepo.UnAssignTeacherToClass(TeacherId, ClassId);
                return Ok("UnAssign Successful");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
