using MediatR;

namespace SimpleCQRSApi.Domain.Business.Customers.GetCustomer;

public class GetCustomerByIdQuery : IRequest<GetCustomerByIdResponse>
{
    public Guid Id { get; set; }
}
