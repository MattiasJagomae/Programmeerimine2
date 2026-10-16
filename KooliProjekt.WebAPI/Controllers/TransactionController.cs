using KooliProjekt.Application.features.Transaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var result = await _mediator.Send(new GetTransactionQuery { Id = id });
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetTransactionListQuery());
            return Ok(result);
        }
    }
}
