using CleanPoc.Application.Command.Leads;
using CleanPoc.Application.Query.Leads;
using CleanPoc.Application.Response.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;
// ReSharper disable RouteTemplates.RouteParameterIsNotPassedToMethod

namespace CleanPoc.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LeadsController : ControllerBase
{
    private readonly IMediator _dispatcher;

    public LeadsController(IMediator dispatcher)
    {
        _dispatcher = dispatcher;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<LeadResponse.List>> List(ListLeadsQuery query) => await _dispatcher.Send(query);
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<LeadResponse.Detail> Get(LeadByIdQuery query) => await _dispatcher.Send(query);
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<LeadResponse.Detail> GetByEmail(LeadByEmailQuery query) => await _dispatcher.Send(query);

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<long> Create(CreateLeadCommand command) => await _dispatcher.Send(command);
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task Update(UpdateLeadCommand command) => await _dispatcher.Send(command);
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task Delete(DeleteLeadCommand command) => await _dispatcher.Send(command);
}