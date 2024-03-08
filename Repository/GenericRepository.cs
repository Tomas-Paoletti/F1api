using f1api.Models;
using F1api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F1api.Repository
{
    public class GenericRepository : IGenericRepository<Driver>
    {
        private readonly F1Context _context;
        public GenericRepository(F1Context context)
        {
            _context = context;
        }

        public async Task Add(Driver entity)
        {
            await _context.Drivers.AddAsync(entity);

        }


        public async Task Save()
        {
           _context.SaveChangesAsync();
        }

        public void Update(Driver entity)
        {
            throw new NotImplementedException();
        }

       public Task Delete(Driver driver)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Driver>> IGenericRepository<Driver>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Driver> IGenericRepository<Driver>.GetById(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
