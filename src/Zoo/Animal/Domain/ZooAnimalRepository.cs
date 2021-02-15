using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Domain.FiltersByCriteria;

namespace Zoo.Animal.Domain
{
    public interface IZooAnimalRepository
    {
        Task Save(ZooAnimal animal);
        Task Update(ZooAnimal animal);
        Task Delete(int id);
        Task<IEnumerable<ZooAnimal>> SearchAll();
        Task<IEnumerable<ZooAnimal>> Matching(Criteria criteria);
        Task<ZooAnimal> FindById(int id);
    }
}