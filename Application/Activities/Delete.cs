using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
         public class Command : IRequest
         {
            public Guid Id { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            public string Category { get; set; }
            public DateTime Date { get; set; }
            public string City { get; set; }
            public string Venue { get; set; }
         }
        
                public class Handler : IRequestHandler<Command>
                {
                    private readonly DataContext _context;
                    public Handler(DataContext context)
                    {
                        _context = context;
        
                    }
        
                    public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                    {
                        // Find activity based on request.
                        var activity = await _context.Activities.FindAsync(request.Id);

                        if(activity == null)
                            throw new Exception("Cannot find Activity");

                        //remove the activity .
                        _context.Remove(activity);

                        var success = await _context.SaveChangesAsync() > 0;
        
                        if(success) return Unit.Value; // Request was successfull.
        
                        throw new Exception("Problem Saving Changes");
        
                    }   
                }
    }
}