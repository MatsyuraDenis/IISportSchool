using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models.EntityConfigurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(25);
            builder.Property(p => p.SecondName).IsRequired().HasMaxLength(25);
        }
    }
}
