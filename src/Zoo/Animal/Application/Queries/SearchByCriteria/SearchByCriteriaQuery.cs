using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shared.Domain.FiltersByCriteria;
using Zoo.Animal.Domain;

namespace Zoo.Animal.Application.Queries.SearchByCriteria
{
    public class SearchByCriteriaQuery : IRequest<IList<ZooAnimal>>
    {
        public List<Dictionary<string, string>> Filters { get; }
        public string OrderBy { get; }
        public string OrderType { get; }
        public int? Limit { get; }
        public int? Offset { get; }

        public SearchByCriteriaQuery(List<Dictionary<string, string>> filters, string orderBy,
            string orderType, int? limit, int? offset)
        {
            Filters = filters;
            OrderBy = orderBy;
            OrderType = orderType;
            Limit = limit;
            Offset = offset;
        }

        public string Name { get; set; }
    }

    // ReSharper disable once UnusedType.Global
    public class SearchByCriteriaQueryHandler : IRequestHandler<SearchByCriteriaQuery, IList<ZooAnimal>>
    {
        private readonly IZooAnimalRepository _repository;

        public SearchByCriteriaQueryHandler(IZooAnimalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<ZooAnimal>> Handle(SearchByCriteriaQuery request, CancellationToken cancellationToken)
        {
            var filters = Filters.FromValues(request.Filters);
            var order = Order.FromValues(request.OrderBy, request.OrderType);

            var criteria = new Criteria(filters, order, request.Limit, request.Offset);
            var animals = (await _repository.Matching(criteria))
                .Select(animal => animal)
                .ToList();

            return animals;
        }
    }
}