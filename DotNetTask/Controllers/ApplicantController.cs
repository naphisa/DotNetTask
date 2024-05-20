using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DotNetTask.Models;
using DotNetTask.Services;
using DotNetTask.Models.DTO;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        private readonly IMapper _mapper;

        public ApplicantController(IApplicantService applicantService, IMapper mapper)
        {
            _applicantService = applicantService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserApplicationDTO item)
        {

            await _applicantService.SubmitApplicationAsync(_mapper.Map<UserApplication>(item));
            //return CreatedAtAction(nameof(Get), new { id = item.id }, item);
            return   NoContent();

        }
    }
}
