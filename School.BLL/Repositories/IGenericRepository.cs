using SchoolApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int Id);

        Task<int> Add(T item);

        Task<int> Delete(T item);
        Task<int> Update(T item);

        Task<IEnumerable<Student>> GetStudentByClassId(int Id);

        Task<int> AddStudentListToClass( int[] StudentId,int Id);

        Task<int> RemoveStudentListToClass(int[] StudentId, int? Id);

        Task<int> AssignTeacherToClass(int TeacherId ,int Id);

        Task<int> UnAssignTeacherToClass(int? TeacherId, int Id);


    }
}
