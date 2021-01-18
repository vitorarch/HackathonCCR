using API.Interfaces.Users.AdditionalInfo;
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
    [Route("/skills")]

    public class SkillController : ControllerBase
    {

        private readonly ISkillRepository _skillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpGet("v1")]
        public IActionResult GetSkill([FromForm] string cpf)
        {
            var skills = _skillRepository.GetSkills(cpf);

            if (skills == null) return NotFound("Habilidade não encontrada");
            else return Ok(skills);
        }

        [HttpPost("v1/add")]
        public async Task<IActionResult> AddSkill([FromForm] Skill skill)
        {
            var _skill = await _skillRepository.AddSkill(skill);

            if (_skill == null) return NotFound("Habilidade não encontrada");
            else return Ok(_skill);
        }

        [HttpPut("v1/edit")]
        public async Task<IActionResult> EditSkill([FromForm] Skill skill)
        {
            var _skill = await _skillRepository.EditSkill(skill);

            if (_skill == null) return NotFound("Habilidade não encontrada");
            else return Ok(_skill);
        }

        [HttpDelete("v1/delete")]
        public async Task<IActionResult> DeleteSkill([FromForm] Guid id)
        {
            var _skill = await _skillRepository.DeleteSkill(id);

            if (_skill == false) return NotFound("Habilidade não encontrada");
            else return Ok(_skill);
        }

    }
}
