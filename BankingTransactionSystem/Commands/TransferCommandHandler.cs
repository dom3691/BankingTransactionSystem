using BankingTransactionSystem.Models;
using BankingTransactionSystem.Repository;
using MediatR;

namespace BankingTransactionSystem.Commands
{
    public class TransferCommandHandler : IRequestHandler<TransferCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public TransferCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(TransferCommand request, CancellationToken cancellationToken)
        {
            var fromCustomer = await _customerRepository.GetCustomerByIdAsync(request.FromCustomerId);
            var toCustomer = await _customerRepository.GetCustomerByIdAsync(request.ToCustomerId);

            if (fromCustomer == null || toCustomer == null)
            {
                throw new Exception("Customer(s) not found");
            }

            if (fromCustomer.Balance < request.Amount)
            {
                throw new Exception("Insufficient funds for transfer");
            }

            // Deduct from sender
            fromCustomer.Balance -= request.Amount;

            var withdrawTransaction = new Transaction
            {
                TransactionType = "Transfer Out",
                Amount = request.Amount,
                TransactionDate = DateTime.Now,
                CustomerId = fromCustomer.Id
            };

            fromCustomer.Transactions.Add(withdrawTransaction);

            // Credit to receiver
            toCustomer.Balance += request.Amount;

            var depositTransaction = new Transaction
            {
                TransactionType = "Transfer In",
                Amount = request.Amount,
                TransactionDate = DateTime.Now,
                CustomerId = toCustomer.Id
            };

            toCustomer.Transactions.Add(depositTransaction);

            // Update both accounts
            await _customerRepository.UpdateCustomerAsync(fromCustomer);
            await _customerRepository.UpdateCustomerAsync(toCustomer);

            return true;
        }
    }

}
