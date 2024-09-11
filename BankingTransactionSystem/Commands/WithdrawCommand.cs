using MediatR;

namespace BankingTransactionSystem.Commands
{
    public class WithdrawCommand : IRequest<bool>
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }

}
