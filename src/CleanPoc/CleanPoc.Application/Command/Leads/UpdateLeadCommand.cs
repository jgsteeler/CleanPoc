using CleanPoc.Application.Request.Leads;
using CleanPoc.Core.Repositories.Command.Leads;
using CleanPoc.Core.Repositories.Query.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanPoc.Application.Command.Leads;

public class UpdateLeadCommand : IRequest<Unit>
{
    [FromRoute]
    public int Id { get; set; }
    [FromBody]
    public LeadRequest.Update Body { get; set; }
    
    internal class UpdateLeadCommandHandler : IRequestHandler<UpdateLeadCommand, Unit>
    {
        private readonly ILeadCommandRepository _commandRepository;
        private readonly ILeadQueryRepository _queryRepository;

        public UpdateLeadCommandHandler( ILeadCommandRepository commandRepository, ILeadQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<Unit> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
        {
            var entity = await _queryRepository.GetLeadById(request.Id, cancellationToken);
            entity.FirstName = request.Body.FirstName;
            entity.LastName = request.Body.LastName;
            entity.Email = request.Body.Email;
            entity.ContactNumber = request.Body.ContactNumber;
            entity.Address = request.Body.Address;
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = request.Body.UserId;
            
            await _commandRepository.UpdateAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
    
}