using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Company.Jobs.AdditionalInfo
{
    public class Differential
    {
        public Guid Id { get; set; }

        [MaxLength(40)]
        public string Knowlegde { get; set; }
    }
}
