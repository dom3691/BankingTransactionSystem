using System.Security.Principal;

namespace BankingTransactionSystem.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}
