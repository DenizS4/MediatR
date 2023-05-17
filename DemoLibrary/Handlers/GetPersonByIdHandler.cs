using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;

namespace DemoLibrary.Handlers;

public class GetPersonByIdHandler: IRequestHandler<GetPersonByIdQuery, Person>
{
    private readonly IMediator _mediator;

    public GetPersonByIdHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetPersonListQuery());

        var output = result.FirstOrDefault(x => x.Id == request.Id);
        
        return output;
    }
}