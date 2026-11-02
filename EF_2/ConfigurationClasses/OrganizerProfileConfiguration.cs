using EF_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_2.ConfigurationClasses
{
    internal class OrganizerProfileConfiguration : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Organizer)
                   .WithOne(o => o.Profile)
                   .HasForeignKey<OrganizerProfile>(p => p.OrganizerId);
        }
    }
}
