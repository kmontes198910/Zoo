using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zoo.Animal.Application.Commands.Create;
using Zoo.Animal.Application.Commands.Update;
using Zoo.Animal.Application.Queries.SearchByCriteria;
using Zoo.Animal.Application.Queries.SearchById;
using ZooBackend.Criteria;

namespace ZooBackend.Controllers
{
    public class AnimalController : BaseApiController
    {
        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAnimal(
            [FromBody] CreateAnimalCommand command, CancellationToken cancellationToken)
        {
            await Mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = "Supervisor")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAnimal(
            int id,
            [FromBody] UpdateAnimalCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            await Mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAnimal(
            int id, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteAnimalCommand(id), cancellationToken);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> FindByCriteria(
            [FromQuery] FiltersParam param, CancellationToken cancellationToken)
        {
            // Testing
            // var filters = new List<Dictionary<string, string>>();
            // var item = new Dictionary<string, string>();
            // item.Add("field", "name");
            // item.Add("operator", "CONTAINS");
            // item.Add("value", "rr");
            // filters.Add(item);
            // param.Filters = filters;

            var animals = await Mediator.Send(
                new SearchByCriteriaQuery(param.Filters, param.OrderBy, param.Order, param.Limit,
                    param.Offset), cancellationToken);

            return Ok(animals);
        }

       
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> FindByIdCriteria(
           int id, CancellationToken cancellationToken)
        {
           var animal = await Mediator.Send(new SearchByIdQuery(id), cancellationToken);

            return Ok(animal);
        }

    }
}