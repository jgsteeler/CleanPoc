using CleanPoc.Application.Request.Leads;
using CleanPoc.Core.Repositories.Command.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanPoc.Application.Command.Leads;

public abstract class CreateLeadCommand : IRequest<long>
{
    [FromRoute]
    public LeadRequest.Create Body { get; set; }
    
    
    internal class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, long>
    {
        private readonly ILeadCommandRepository _commandRepository;

        public CreateLeadCommandHandler( ILeadCommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<long> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            var entity = new Core.Entities.Lead
            {
                FirstName = request.Body.FirstName,
                LastName = request.Body.LastName,
                Email = request.Body.Email,
                ContactNumber = request.Body.ContactNumber,
                Address = request.Body.Address,
                CreatedDate = DateTime.Now,
            };
            
            var result =  await _commandRepository.AddAsync(entity, cancellationToken);

            return result.Id;
}
    }
    
}