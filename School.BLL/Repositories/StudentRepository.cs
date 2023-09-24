using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.Data;
using SchoolApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.Repositories
{
    public class StudentRepository : GenericRepository<Student> , IStudentRepository
    {
        private readonly SchoolContext _schoolContext;
        public StudentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            _schoolContext = schoolContext;
        }
        //public async Task<IEnumerable<Student>> GetStudentByClassId(int ClassId)
        //{
        //    var getStudents = await _schoolContext.Students.Where(S => S.ClassId == ClassId).ToListAsync();

        //    return getStudents;
        //}
    }
}
