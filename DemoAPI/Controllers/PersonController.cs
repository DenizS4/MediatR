using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoLibrary.Commands;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/Person
        [HttpGet]
        public async Task<List<Person>> Get()
        {
            return await _mediator.Send(new GetPersonListQuery());
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await _mediator.Send(new GetPersonByIdQuery(id));
        }

        // POST: api/Person
        [HttpPost]
        public async Task<Person> Post([FromBody] Person value)
        {
            return await _mediator.Send(new InsertPersonCommand(value.FirstName, value.LastName));
        }

 
    }
}
