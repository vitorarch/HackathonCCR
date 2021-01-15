using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.User
{
    public class UserModel
    {
        [Required]
        [MaxLength(14)]
        public string CPF { get; set; }

        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public long PIS { get; set; }

        [Required]
        [MaxLength(7)]
        public long WorkCardNumber { get; set; }

        [Required]
        [MaxLength(5)]
        public long Serie { get; set; }

        [Required]
        [MaxLength(11)]
        public string RG { get; set; }

        [Required]
        [MaxLength(13)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(40)]
        public string Email { get; set; }

        [Required]
        [MaxLength(70)]
        public string Adress { get; set; }

        [Required]
        [MaxLength(5)]
        public int Number { get; set; }

        [MaxLength(20)]
        public string Compelment { get; set; }

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

        [Required]
        [MaxLength(15)]
        public string Naturalness { get; set; }

        [Required]
        [MaxLength(12)]
        public string Color { get; set; }

    }
}
