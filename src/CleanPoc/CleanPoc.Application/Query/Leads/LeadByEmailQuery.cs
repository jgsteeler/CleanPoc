using CleanPoc.Application.Response.Leads;
using CleanPoc.Core.Repositories.Query.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanPoc.Application.Query.Leads;

public class LeadByEmailQuery : IRequest<LeadResponse.Detail>
{
    [FromQuery]
    public string Email { get; set; }
    
    internal class LeadByEmailQueryHandler : IRequestHandler<LeadByEmailQuery, LeadResponse.Detail>
    {
        private readonly ILeadQueryRepository _leadQueryRepository;

        public LeadByEmailQueryHandler(ILeadQueryRepository leadQueryRepository)
        {
            _leadQueryRepository = leadQueryRepository;
        }

        public async Task<LeadResponse.Detail> Handle(LeadByEmailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _leadQueryRepository.GetLeadByEmail(request.Email, cancellationToken);
            
           
            return LeadResponse.Detail.Selector.Compile().Invoke(entity);
        }
    }
    
}