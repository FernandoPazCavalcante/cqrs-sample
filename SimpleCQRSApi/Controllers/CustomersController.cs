using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCQRSApi.Domain.Business.Customers.CreateCustomer;
using SimpleCQRSApi.Domain.Business.Customers.GetCustomer;

namespace SimpleCQRSApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] GetCustomerByIdQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(response);
    }
}
