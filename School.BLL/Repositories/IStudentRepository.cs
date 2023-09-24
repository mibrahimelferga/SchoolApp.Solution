﻿using SchoolApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.Repositories
{
    public interface IStudentRepository :IGenericRepository<Student>
    {
        //Task<IEnumerable<Student>> GetStudentByClassId(int Id);
    }
}
