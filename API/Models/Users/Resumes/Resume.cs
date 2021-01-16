using API.Models.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Users.Resumes
{
    public class Resume
    {
        public Guid Id { get; set; }

        [MaxLength(70)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public string Photo { get; set; }

        public IEnumerable<Education> Education { get; set; } = new List<Education>();

        public IEnumerable<Experience> Experiences { get; set; } = new List<Experience>();

        public IEnumerable<Skill> Skills { get; set; } = new List<Skill>();

    }
}
