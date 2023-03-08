using CleanPoc.Application.Response.Leads;
using CleanPoc.Core.Repositories.Query.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanPoc.Application.Query.Leads;

public class ListLeadsQuery : IRequest<List<LeadResponse.List>>
{
    /// <summary>
    /// Optional Address Filter
    /// </summary>
    [FromQuery]
    public string Address { get; set; }
    
    internal class ListLeadsQueryHandler : IRequestHandler<ListLeadsQuery, List<LeadResponse.List>>
    {
        private readonly ILeadQueryRepository _leadQueryRepository;

        public ListLeadsQueryHandler(ILeadQueryRepository leadQueryRepository)
        {
            _leadQueryRepository = leadQueryRepository;
        }

        public async Task<List<LeadResponse.List>> Handle(ListLeadsQuery request, CancellationToken cancellationToken)
        {
            
            
            var query = await _leadQueryRepository.GetAllAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.Address))
            {
                query = query.Where(x => x.Address == request.Address);
            }
            var result = query.Select(LeadResponse.List.Selector).ToList();
            
            
            return result;
        }
    }
}