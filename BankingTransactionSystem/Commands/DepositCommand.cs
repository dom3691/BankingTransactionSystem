using MediatR;

namespace BankingTransactionSystem.Commands
{
    public class DepositCommand : IRequest<bool>
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }

}
