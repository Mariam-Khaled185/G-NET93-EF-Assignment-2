using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_2.Models
{
    internal class OrganizerProfile
    {
        public int Id { get; set; }
        public string Bio { get; set; }

        public string? Website { get; set; }

        public string? Logo { get; set; }
        public Organizer Organizer { get; set; }
        public int OrganizerId { get; set; }
    }
}
