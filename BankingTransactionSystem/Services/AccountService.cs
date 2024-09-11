using BankingTransactionSystem.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace BankingTransactionSystem.Services
{
    public class AccountService
    {
        private readonly IDatabase _cache;

        public AccountService(IConnectionMultiplexer redis)
        {
            _cache = redis.GetDatabase();
        }

        //public async Task<Account> GetAccountBalance(int accountId)
        //{
        //    string cacheKey = $"account_balance_{accountId}";
        //    string balance = await _cache.StringGetAsync(cacheKey);

        //    if (balance == null)
        //    {
        //        var account = await _context.Accounts.FindAsync(accountId);
        //        balance = account.Balance.ToString();
        //        await _cache.StringSetAsync(cacheKey, balance);
        //    }

        //    return Convert.ToDecimal(balance);
        //}
    }
}
