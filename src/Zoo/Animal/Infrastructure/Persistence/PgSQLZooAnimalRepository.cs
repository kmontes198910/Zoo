using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.FiltersByCriteria;
using Shared.Infrastructure.Persistence.EntityFramework.Criteria;
using Zoo.Animal.Domain;
using Zoo.Shared.Infrastructure.Persistence.EntityFramework;

namespace Zoo.Animal.Infrastructure.Persistence
{
    public class PgSqlZooAnimalRepository : IZooAnimalRepository
    {
        private readonly ZooContext _context;

        public PgSqlZooAnimalRepository(ZooContext context)
        {
            _context = context;
        }

        public async Task Save(ZooAnimal animal)
        {
            await _context.Animals.AddAsync(animal);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ZooAnimal animal)
        {
            _context.Update(animal);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Animals.Remove(new ZooAnimal {Id = id});
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ZooAnimal>> SearchAll()
        {
            return await _context.Animals.ToListAsync();
        }

        public async Task<IEnumerable<ZooAnimal>> Matching(Criteria criteria)
        {
            return await _context.Animals.SearchByCriteria(criteria).ToListAsync();
        }

        public Task<ZooAnimal> FindById(int Id)
        {
            return _context.Animals.FirstOrDefaultAsync(animal => animal.Id == Id);
        }
    }
}