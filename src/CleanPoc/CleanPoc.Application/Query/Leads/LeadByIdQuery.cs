using CleanPoc.Application.Response.Leads;
using CleanPoc.Core.Repositories.Query.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanPoc.Application.Query.Leads;

public class LeadByIdQuery : IRequest<LeadResponse.Detail>
{
    
    [FromRoute]
    public int Id { get; set; }
    
    internal class LeadByIdQueryHandler : IRequestHandler<LeadByIdQuery, LeadResponse.Detail>
    {
        private readonly ILeadQueryRepository _leadQueryRepository;

        public LeadByIdQueryHandler(ILeadQueryRepository leadQueryRepository)
        {
            _leadQueryRepository = leadQueryRepository;
        }

        public async Task<LeadResponse.Detail> Handle(LeadByIdQuery request, CancellationToken cancellationToken)
        {
            return LeadResponse.Detail.Selector.Compile().Invoke(await _leadQueryRepository.GetLeadById(request.Id, cancellationToken));
        }
    }
    
}