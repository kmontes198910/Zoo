using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zoo.Animal.Domain;

namespace Zoo.Animal.Application.Commands.Update
{
    public class UpdateAnimalCommand : IRequest
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int Age { get; set; }
        [Required] public string Description { get; set; }
    }

    // ReSharper disable once UnusedType.Global
    public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommand>
    {
        private readonly IZooAnimalRepository _repository;

        public UpdateAnimalCommandHandler(IZooAnimalRepository repository)
        {
            _repository = repository;
        }


        public async Task<Unit> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            var animal = await _repository.FindById(request.Id)
                         ?? throw new AnimalNotFoundException();

            animal.Name = request.Name;
            animal.Description = request.Description;
            animal.Age = request.Age;

            await  _repository.Update(animal);
            
            return Unit.Value;
        }
    }
}