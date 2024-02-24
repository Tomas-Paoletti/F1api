using f1api.Models;
using f1api.Service.IService;

namespace f1api.Service
{
    public class DriverService : IDriverService
    {
        public Task Create(Driver entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Driver entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Driver>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Driver?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Driver>> GetCardDriversAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Driver entity)
        {
            throw new NotImplementedException();
        }
    }
}
