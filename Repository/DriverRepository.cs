using f1api.DTOs;
using f1api.Models;
using F1api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F1api.Repository
{
    public class DriverRepository :  IDriverRepository
    {
        private readonly F1Context _context;
        public DriverRepository(F1Context context)
        {
            _context = context;
        }

        public async Task Add(Driver entity)
        {
            await _context.Drivers.AddAsync(entity);
        }

        public async Task Delete(Driver driver)
        {
            
             
            _context.Drivers.Remove(driver);
        }

        public async Task<IEnumerable<Driver>> GetAll()
        {
          return await  _context.Drivers.ToListAsync();
        }


        public async Task<Driver> GetById(int id)
        {
            Driver driver = new Driver { Id = id };

           
           var DriverFind= await _context.Drivers.FindAsync(driver.Id);
            return DriverFind;
        }

        public Task<CardDriverDto> GetCardDriver(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task Save()
        {
           await _context.SaveChangesAsync();
        }

        public void Update(Driver entity)
        {
             _context.Update(entity);
         
        }
    }
}
