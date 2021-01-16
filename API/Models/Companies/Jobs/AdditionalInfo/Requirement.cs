using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Company.Jobs.AdditionalInfo
{
    public class Requirement
    {
        public Guid Id { get; set; }

        [MaxLength(40)]
        public string Requesite { get; set; }
    }
}
