using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Users.AdditionalInfo
{
    public class Education
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Institution { get; set; }

        [Required]
        [MaxLength(50)]
        public string Degree { get; set; }

        [Required]
        [MaxLength(50)]
        public string FieldOfStudy { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }



    }
}
