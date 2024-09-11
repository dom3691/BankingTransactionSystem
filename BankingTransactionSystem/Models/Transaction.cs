namespace BankingTransactionSystem.Models;

public class Transaction
{
    public int Id { get; set; }
    public string TransactionType { get; set; } 
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}