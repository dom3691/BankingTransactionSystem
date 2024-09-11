using BankingTransactionSystem.Commands;
using BankingTransactionSystem.Data;
using BankingTransactionSystem.Models;
using BankingTransactionSystem.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingTransactionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var customerId = await _mediator.Send(command);
            return Ok(customerId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery { Id = id });
            return Ok(customer);
        }

        [HttpPost("{id}/deposit")]
        public async Task<IActionResult> Deposit(int id, [FromBody] decimal amount)
        {
            var result = await _mediator.Send(new DepositCommand { CustomerId = id, Amount = amount });
            return result ? Ok() : StatusCode(500, "Deposit failed");
        }

        // Withdraw from an Account
        [HttpPost("{id}/withdraw")]
        public async Task<IActionResult> Withdraw(int id, [FromBody] decimal amount)
        {
            var result = await _mediator.Send(new WithdrawCommand { CustomerId = id, Amount = amount });
            return result ? Ok() : StatusCode(500, "Withdrawal failed");
        }

        // Transfer between Accounts
        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok() : StatusCode(500, "Transfer failed");
        }
    }
}
