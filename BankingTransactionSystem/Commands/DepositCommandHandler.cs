using BankingTransactionSystem.Models;
using BankingTransactionSystem.Repository;
using MediatR;

namespace BankingTransactionSystem.Commands
{
    public class DepositCommandHandler : IRequestHandler<DepositCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public DepositCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(request.CustomerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            customer.Balance += request.Amount;

            var transaction = new Transaction
            {
                TransactionType = "Deposit",
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
