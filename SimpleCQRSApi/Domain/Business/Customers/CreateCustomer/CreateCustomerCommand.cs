using MediatR;

namespace SimpleCQRSApi.Domain.Business.Customers.CreateCustomer;

public class CreateCustomerCommand : IRequest<CreateCustomerResponse>
{
    public string Name { get; set; }
    public string Email { get; set; }
}
