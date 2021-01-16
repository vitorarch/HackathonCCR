﻿using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Users.AdditionalInfo
{
    public class Experience
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Position { get; set; }

        [Required]
        [MaxLength(30)]
        public string Company { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime? ResignationDate { get; set; }

    }
}
