﻿using API.Interfaces.Users.AdditionalInfo;
using API.Models.Users.AdditionalInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Users.AdditionalInfo
{

    [ApiController]
    //[Authorize]
    [Route("/experiences")]

    public class ExperienceController : ControllerBase
    {

        private readonly IExperienceRepository _experienceRepository;

        public ExperienceController(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        [HttpGet("v1")]
        public IActionResult GetExperience(string cpf)
        {
            var experiences = _experienceRepository.GetExperiences(cpf);

            if (experiences == null) return NotFound("Experiência não encontrada");
            else return Ok(experiences);
        }

        [HttpPost("v1/add")]
        public async Task<IActionResult> AddExperience([FromBody] Experience experience)
        {
            var _experience = await _experienceRepository.AddExperience(experience);

            if (_experience == null) return NotFound("Experiência não encontrada");
            else return Ok(_experience);
        }

        [HttpPut("v1/edit")]
        public async Task<IActionResult> EditExperience([FromBody] Experience experience)
        {
            var _experience = await _experienceRepository.EditExperience(experience);

            if (_experience == null) return NotFound("Experiência não encontrada");
            else return Ok(_experience);
        }

        [HttpDelete("v1/delete")]
        public async Task<IActionResult> DeleteExperience([FromBody] Guid id)
        {
            var _experience = await _experienceRepository.DeleteExperience(id);

            if (_experience == false) return NotFound("Experiência não encontrada");
            else return Ok(_experience);
        }

    }
}
