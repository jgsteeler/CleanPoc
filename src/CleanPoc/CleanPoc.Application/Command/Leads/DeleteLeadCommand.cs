using CleanPoc.Core.Repositories.Command.Leads;
using CleanPoc.Core.Repositories.Query.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanPoc.Application.Command.Leads;

public class DeleteLeadCommand : IRequest<Unit>
{
    [FromRoute]
    public int Id { get; set; }
    
    internal class DeleteLeadCommandHandler : IRequestHandler<DeleteLeadCommand, Unit>
    {
        private readonly ILeadCommandRepository _commandRepository;
        private readonly ILeadQueryRepository _queryRepository;

        public DeleteLeadCommandHandler( ILeadCommandRepository commandRepository, ILeadQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<Unit> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
        {
            var entity = await _queryRepository.GetLeadById(request.Id, cancellationToken);
            if (entity == null)
            {
                return Unit.Value;
            }
            await _commandRepository.DeleteAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
    
}