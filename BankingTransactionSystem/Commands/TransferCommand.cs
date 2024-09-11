using MediatR;

namespace BankingTransactionSystem.Commands
{
    public class TransferCommand : IRequest<bool>
    {
        public int FromCustomerId { get; set; }
        public int ToCustomerId { get; set; }
        public decimal Amount { get; set; }
    }

}
