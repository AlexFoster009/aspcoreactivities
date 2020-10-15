using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace Application.Activities
{
    public class List
    {
        // This funtion will lsit the activities from our database.

        //1. Create a query
        // We want to return a list of activities.
        public class Query : IRequest<List<Activity>> { }
        //2. Create a Handler.
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            public readonly DataContext _context;
        
            public Handler(DataContext context, ILogger<List> logger)
            {
    
                _context = context;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
        

                // Get a list of activities and return them.
                var activities = await _context.Activities.ToListAsync();
                return activities;
            }
       
        }
    }
}