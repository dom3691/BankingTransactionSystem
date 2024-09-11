using MediatR;

namespace BankingTransactionSystem.Commands;

public class CreateCustomerCommand : IRequest<int>
{
    public string Name { get; set; }
    public int AccountNumber { get; set; }
}
