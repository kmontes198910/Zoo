using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zoo.Animal.Domain;

namespace Zoo.Animal.Application.Commands.Update
{
    public class DeleteAnimalCommand : IRequest
    {
        public DeleteAnimalCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }

    // ReSharper disable once UnusedType.Global
    public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand>
    {
        private readonly IZooAnimalRepository _repository;

        public DeleteAnimalCommandHandler(IZooAnimalRepository repository)
        {
            _repository = repository;
        }


        public async Task<Unit> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
            return Unit.Value;
        }
    }
}