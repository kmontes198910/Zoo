using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zoo.Animal.Domain;

namespace Zoo.Animal.Application.Commands.Create
{
    public class CreateAnimalCommand : IRequest
    {
        [Required] public string Name { get; set; }
        [Required] public int Age { get; set; }
        [Required] public string Description { get; set; }
    }

    // ReSharper disable once UnusedType.Global
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand>
    {
        private readonly IZooAnimalRepository _repository;

        public CreateAnimalCommandHandler(IZooAnimalRepository repository)
        {
            _repository = repository;
        }


        public async Task<Unit> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            await _repository.Save(new ZooAnimal
            {
                Name = request.Name,
                Age = request.Age,
                Description = request.Description,
            });

            return Unit.Value;
        }
    }
}