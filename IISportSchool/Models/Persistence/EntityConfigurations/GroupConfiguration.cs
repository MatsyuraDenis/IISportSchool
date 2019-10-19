using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IISportSchool.Models.EntityConfigurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(63);
            builder.HasAlternateKey(b=>b.Name);
        }
    }
}
