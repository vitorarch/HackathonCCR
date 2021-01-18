using API.Interfaces.Companies;
using API.Models.Companies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Companies
{

    [ApiController]
    [Authorize]
    [Route("company")]

    public class CompanyController : ControllerBase
    {

        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet("v1")]
        public async Task<IActionResult> GetProfile([FromBody] string id)
        {
            var company = await _companyRepository.GetCompanyProfile(id);

            if (company == null) return NotFound("Empresa não encontrada");
            else return Ok(company);
        }

        [HttpGet("v1/edit")]
        public async Task<IActionResult> EditProfile([FromBody] Company company)
        {
            var _company = await _companyRepository.EditCompanyProfile(company);

            if (_company == null) return NotFound("Empresa não encontrada");
            else return Ok(_company);
        }

        [HttpGet("v1/delete")]
        public async Task<IActionResult> DeleteProfile([FromBody] string cpf)
        {
            var _company = await _companyRepository.DeleteCompanyProfile(cpf);

            if (_company == false) return NotFound("Empresa não encontrada");
            else return Ok("Empresa deletada");
        }


    }
}
