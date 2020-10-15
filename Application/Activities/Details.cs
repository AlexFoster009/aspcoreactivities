using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Activity> 
        {
               /*
                    Specifiy the id on the activity requested. This in theory will perform a GET request
                    qyierying the fsrt result that matches the GUID in the query string. /api/activty/1
                    or something along those lines.
               */

            public Guid Id {get; set;}



        }

        /*
            Pass in the query type and the activity we are returning.
        */
        public class Handler : IRequestHandler<Query, Activity>
        {

            private readonly DataContext _context;
            // Generate Constructor for the handler.

            public Handler(DataContext context)
            {
                _context = context;
                
            }
             public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                /*
                    This is our Handler for our detail. This will load an activity 
                    and losd the details that pertain to it by reference the ID in the data base.
                */
                
                var activity = await _context.Activities.FindAsync(request.Id);
                //return the activity
                return activity;
            
            }
        }
    }
}