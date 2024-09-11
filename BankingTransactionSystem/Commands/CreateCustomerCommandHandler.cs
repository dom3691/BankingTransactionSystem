using BankingTransactionSystem.Models;
using BankingTransactionSystem.Repository;
using MediatR;

namespace BankingTransactionSystem.Commands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Name = request.Name,
            AccountNumber = request.AccountNumber,
            Balance = 0m,
            Transactions = new List<Transaction>()
        };

        await _repository.AddCustomerAsync(customer);
        return customer.Id;
    }
}