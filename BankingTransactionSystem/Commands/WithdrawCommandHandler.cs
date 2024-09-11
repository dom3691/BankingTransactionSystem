using BankingTransactionSystem.Models;
using BankingTransactionSystem.Repository;
using MediatR;

namespace BankingTransactionSystem.Commands
{
    public class WithdrawCommandHandler : IRequestHandler<WithdrawCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public WithdrawCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(WithdrawCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(request.CustomerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            // Ensure the balance is enough for withdrawal
            if (customer.Balance < request.Amount)
            {
                throw new Exception("Insufficient funds");
            }

            customer.Balance -= request.Amount;

            var transaction = new Transaction
            {
                TransactionType = "Withdrawal",
                Amount = request.Amount,
                TransactionDate = DateTime.Now,
                CustomerId = customer.Id
            };

            customer.Transactions.Add(transaction);

            await _customerRepository.UpdateCustomerAsync(customer);

            return true;
        }
    }

}
