using MediatR;
using SimpleCQRSApi.Domain.Business.Customers.CreateCustomer;
using SimpleCQRSApi.Domain.Common;
using SimpleCQRSApi.Domain.Entities;

namespace SimpleCQRSApi.Handlers.Customers;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
{
    private readonly IRepository<Customer> _customerRepository;

    public CreateCustomerHandler(IRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        Customer customer = new (command.Email, command.Name);

        await _customerRepository.Insert(customer);

        return new CreateCustomerResponse{
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            CreatedAt = customer.CreatedAt
        };
    }
}
