using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetTask.Data;
using DotNetTask.Models;
using AutoMapper;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Newtonsoft.Json;
using DotNetTask.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNetTask.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;
        private readonly IMapper _mapper;

        public EmployerController(IEmployerService cosmosDbService, IMapper mapper)
        {
            _employerService = cosmosDbService;
            _mapper = mapper;
        }

        // GET: api/ProgramInformation
        // /Get all form in database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramInformationDTO>>> Get()
        {
            var pi = await _employerService.GetItemsAsync("SELECT * FROM c");
            //IEnumerable<ProgramInformationDTO> piDTO = _mapper.Map<IEnumerable<ProgramInformationDTO>>(pi);
            return Ok(_mapper.Map<IEnumerable<ProgramInformationDTO>>(pi));
        }

        // GET: api/ProgramInformation/5, Get employer form for Applicants
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramInformation>> Get(string id)
        {
            ProgramInformation pi = new ProgramInformation();
            var item = await _employerService.GetItemAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST: api/ProgramInformation, 
        //Create application Form
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProgramInformationDTO item)
        {
            //var question = JsonSerializer.Deserialize<Question>(item.questions);
            await _employerService.AddItemAsync(_mapper.Map<ProgramInformation>(item));
            return NoContent();

        }


        // PUT: api/ProgramInformation/5
        //Update programm information
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] ProgramInformation item)
        {
            if (id != item.id.ToString())
            {
                return BadRequest();
            }

            await _employerService.UpdateItemAsync(id, item);
            return NoContent();
        }

    }

}
