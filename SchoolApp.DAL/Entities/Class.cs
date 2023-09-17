using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.Entities
{
    public class Class
    {
        
        public int ClassId { get; set; }

        public ICollection<Student> Students { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
