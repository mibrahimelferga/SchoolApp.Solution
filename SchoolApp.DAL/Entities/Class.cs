using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.Entities
{
    public class Class
    {
        
        public int ClassId { get; set; }
        public int ClassNumber { get; set; }
        public ICollection<Student> Students { get; set; }
        [AllowNull]
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
