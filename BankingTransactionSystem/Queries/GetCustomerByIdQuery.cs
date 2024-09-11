using BankingTransactionSystem.Models;
using MediatR;

namespace BankingTransactionSystem.Queries;

public class GetCustomerByIdQuery: IRequest<Customer>
{
    public int Id { get; set; }
}
