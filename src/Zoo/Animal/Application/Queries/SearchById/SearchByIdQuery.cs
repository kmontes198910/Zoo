using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shared.Domain.FiltersByCriteria;
using Zoo.Animal.Domain;

namespace Zoo.Animal.Application.Queries.SearchById
{
    public class SearchByIdQuery : IRequest<ZooAnimal>
    {
        public int Id { get; }
      

        public SearchByIdQuery( int id)
        {
            Id = id;
        }

    }
    public class SearchByIdQueryyHandler : IRequestHandler<SearchByIdQuery, ZooAnimal>
    {
        private readonly IZooAnimalRepository _repository;

        public SearchByIdQueryyHandler(IZooAnimalRepository repository)
        {
            _repository = repository;
        }

        public async Task<ZooAnimal> Handle(SearchByIdQuery request, CancellationToken cancellationToken)
        {
            var animal = (await _repository.FindById(request.Id));

            return animal;
        }
    }

}