
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain;
using System;
using
using System.Threading;

namespace API.Controllers
{
    /*
     * All API controllers need a route.
     */

    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        /*
            When this route is hit, this controller will fire,
            when the request is recieved the reponse will then send a new list of activity objects 
            to the front end of the app.
        */

        private readonly IMediator _mediator;
        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // create a get request to recieve our list inside out client app.
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> List(CancellationToken ct)
        {
            return await _mediator.Send(new List.Query(), ct);
        }

        [HttpGet("{id}")]
        // Return a result, this being a single entity and its details

        public async Task<ActionResult<Activity>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query{Id = id});
        }

    }


}