using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.Data.Config
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(S => S.StudenName).IsRequired().HasMaxLength(100);
            builder.Property(S => S.StudenAdress).IsRequired();
            builder.Property(S => S.StudenAge).IsRequired();
            builder.HasOne(S => S.Class).WithMany(C => C.Students)
                .HasForeignKey(S => S.ClassId);
        }
    }
}
