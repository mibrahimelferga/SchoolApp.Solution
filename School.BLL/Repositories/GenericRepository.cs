using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.Data;
using SchoolApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace School.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly SchoolContext _context;

        public GenericRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        { 
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
     => await _context.Set<T>().FindAsync(id);


        public async Task<int> Add(T item)
        {
            await _context.Set<T>().AddAsync(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(T item)
        {
            _context.Set<T>().Remove(item);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Update(T item)
        {
            _context.Set<T>().Update(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentByClassId(int ClassId)
        {
            var getStudents = await _context.Students.Where(S => S.ClassId == ClassId).ToListAsync();

            return getStudents;
        }


        public async Task<int> AddStudentListToClass(int []StudentsId ,int ClassId)
        {

            foreach (int st_id in StudentsId)
            {

                 var student =  await _context.Students.Where(S => S.StudentId == st_id ).FirstOrDefaultAsync();

                student.ClassId = ClassId;
                
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveStudentListToClass(int[] StudentsId, int? ClassId)
        {

            foreach (int st_id in StudentsId)
            {

                var student = await _context.Students.Where(S => S.StudentId == st_id).FirstOrDefaultAsync();

                student.ClassId = null;

            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AssignTeacherToClass(int TeachetId,int ClassId)
        {

            

                var teacher = await _context.Classes.Where( C => C.ClassId == ClassId ).FirstOrDefaultAsync();

                teacher.TeacherId= TeachetId;

               return await _context.SaveChangesAsync();
        }

        public async Task<int> UnAssignTeacherToClass(int? TeachetId, int ClassId)
        {

            var teacher = await _context.Classes.Where(C => C.ClassId == ClassId).FirstOrDefaultAsync();

            teacher.TeacherId = null ;

            return await _context.SaveChangesAsync();
        }


    }

}

