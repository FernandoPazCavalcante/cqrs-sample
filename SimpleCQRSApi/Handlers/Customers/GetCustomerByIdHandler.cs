using MediatR;
using SimpleCQRSApi.Domain.Business.Customers.GetCustomer;
using SimpleCQRSApi.Domain.Common;
using SimpleCQRSApi.Domain.Entities;

namespace SimpleCQRSApi.Handlers.Customers;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdResponse>
{
    private readonly IRepository<Customer> _customerRepository;

    public GetCustomerByIdHandler(IRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.Get(query.Id);

        return new GetCustomerByIdResponse
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            CreatedAt = customer.CreatedAt
        };
    }
}
