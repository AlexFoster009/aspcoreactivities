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
            private readonly ILogger<List> _logger;
            public Handler(DataContext context, ILogger<List> logger)
            {
                _logger = logger;
                _context = context;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    for (var i = 0; i < 10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, cancellationToken);

                        _logger.LogInformation($"Task {i} has completed");
                    }
                } catch (Exception ex) when (ex is TaskCanceledException){

                    _logger.LogInformation("Task was cancelled");
                    
                }


                // Get a list of activities and return them.
                var activities = await _context.Activities.ToListAsync(cancellationToken);
                return activities;
            }
        }
    }
}