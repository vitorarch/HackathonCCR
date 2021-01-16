using API.Models.Company.Jobs.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Company.Jobs
{
    public class Job
    {

        public Guid JobId { get; set; }

        [MaxLength(15)]
        public string Position { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public IEnumerable<Requirement> Requirements { get; set; } = new List<Requirement>();

        public IEnumerable<Differential> Differentials { get; set; } = new List<Differential>();

        public IEnumerable<JobManagement> Applications { get; set; } = new List<JobManagement>();

        [MaxLength(25)]
        public string PayRange { get; set; }

        [MaxLength(20)]
        public string Category { get; set; }

    }
}
