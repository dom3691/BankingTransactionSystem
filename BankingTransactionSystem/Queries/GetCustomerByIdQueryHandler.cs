using BankingTransactionSystem.Models;
using BankingTransactionSystem.Repository;
using MediatR;

namespace BankingTransactionSystem.Queries;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByIdQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetCustomerByIdAsync(request.Id);
    }
}