﻿using API.Models.Company.Jobs.AdditionalInfo;
using API.Models.Users.Resumes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Users
{
    public class User
    {
        [Key]
        [Required]
        [MaxLength(14)]
        public string CPF { get; set; }

        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        [MaxLength(13)]
        public string Phone { get; set; }

        [MaxLength(40)]
        public string Email { get; set; }

        [Required]
        [MaxLength(70)]
        public string Adress { get; set; }

        [Required]
        [MaxLength(5)]
        public int Number { get; set; }

        [MaxLength(20)]
        public string Complement { get; set; }

        [Required]
        [MaxLength(20)]
        public string Neighborhood { get; set; }

        [Required]
        [MaxLength(20)]
        public string State { get; set; }

        [Required]
        [MaxLength(20)]
        public string City { get; set; }

        [Required]
        [MaxLength(9)]
        public string CEP { get; set; }

        [Required]
        [MaxLength(20)]
        public string Gender { get; set; }

        [Required]
        public DateTime BithDate { get; set; }

        public string Photo { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public Resume Resume { get; set; }

        public IEnumerable<JobManagement> Applications { get; set; } = new List<JobManagement>();
    }
}
