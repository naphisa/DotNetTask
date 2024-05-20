using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using DotNetTask.Services;
using AutoMapper;
using DotNetTask.Models.DTO;
using DotNetTask.Models;
using System.Xml.Linq;
namespace TestProgramAPIs
{
    internal class EmployeeControllerTest
    {
        // Define the necessary DTO and service interfaces for the test

        public class ProgramInformationController : ControllerBase
        {
            private readonly IEmployerService _employerService;
            private readonly IMapper _mapper;

            public ProgramInformationController(IEmployerService employerService, IMapper mapper)
            {
                _employerService = employerService;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<ProgramInformationDTO>>> Get()
            {
                var pi = await _employerService.GetItemsAsync("SELECT * FROM c");
                return Ok(_mapper.Map<IEnumerable<ProgramInformationDTO>>(pi));
            }
        }

        public class ProgramInformationControllerTests
        {
            private readonly IEmployerService _testEmployerService;
            private readonly IMapper _testMapper;
            private readonly ProgramInformationController _controller;

            public ProgramInformationControllerTests(IMapper testMapper, IEmployerService testEmployerService, ProgramInformationController controller)
            {
                _testEmployerService = testEmployerService;
                _testMapper = testMapper;
                _controller = controller;
            }

            [Fact]
            public async Task EmployerControllerPostMethodTest()
            {
                // Arrange
                DateQuestion[] dq = new[]
                         {
                             new DateQuestion
                             {  QuestionText = "When did you graduate from school?" },
                             new DateQuestion
                             {  QuestionText = "What year did you get your first job?" },
                         };
                var programInformationList = new ProgramInformation { 

                        id = "2",
                        ProgramTitle = "Graduate Trainee Program",
                        ProgramDescription = "Give technical training to graduates",
                        MChoiceQuestions = new[]
                         {
                            new MultipleChoiceQuestion
                            {
                                QuestionText = "What are your favorite colours?",
                                questionChoice = new string[]{ "blue", "black","yellow", "pink", "green" },
                            }
                        },
                         DateQuestion = new []
                         {
                             new DateQuestion
                             {  QuestionText = "When did you graduate from school?" },
                             new DateQuestion
                             {  QuestionText = "What year did you get your first job?" },
                         },
                     
                };
                
                //Assert.Contains(dq, programInformationList.DateQuestion);
            }



        }
};



    
}
