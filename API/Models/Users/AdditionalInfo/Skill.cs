using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Users.AdditionalInfo
{
    public class Skill
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Knowledge { get; set; }
    }
}
