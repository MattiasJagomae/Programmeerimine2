using KooliProjekt.Application.features.Asset;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssetsController(IMediator mediator)
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

            var result = await _mediator.Send(new GetAssetQuery { Id = id });
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAssetListQuery());
            return Ok(result);
        }
    }
}