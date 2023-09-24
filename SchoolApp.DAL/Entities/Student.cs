using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.Entities
{
    public class Student
    {
        public int StudentId { get; set; } 
        public String StudenName { get; set; }

        public string StudenAdress { get; set; }
        public int StudenAge { get; set; }
        [AllowNull]
        public int? ClassId { get; set; }    

        public Class Class { get; set; }

    }
}
