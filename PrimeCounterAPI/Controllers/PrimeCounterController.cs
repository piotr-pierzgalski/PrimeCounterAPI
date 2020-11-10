using System.Threading.Tasks;
using Commands.CreatePrimeCounter;
using Commands.DeletePrimeCounter;
using Commands.IncrementPrimeCounter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Queries.GetPrimeCounter;

namespace PrimeCounterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeCounterController : ControllerBase
    {
        private IMediator _mediator;

        public PrimeCounterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult<GetPrimeCounterQueryResult>> GetPrimeCounter(string name)
        {
            var result = await _mediator.Send(new GetPrimeCounterQuery(name));

            if (!result.Item1)
            {
                return NotFound();
            }
            else
            {
                return result.Item2;
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreatePrimeCounter(string name)
        {
            var result = await _mediator.Send(new CreatePrimeCounterCommand(name));

            if(!result)
            {
                return Conflict();
            }
            else
            { 
                return Ok();
            }
        }

        [HttpPost("increment")]
        public async Task<ActionResult> IncrementPrimeCounter(string name)
        {
            var result = await _mediator.Send(new IncrementPrimeCounterCommand(name));

            if (!result)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePrimeCounter(string name)
        {
            var result = await _mediator.Send(new DeletePrimeCounterCommand(name));

            if (!result)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}