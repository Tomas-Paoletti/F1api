using f1api.DTOs;
using f1api.Models;
using f1api.Service.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Text.Json;

namespace f1api.Service
{
    public class DriverService : IDriverService
    {
        private F1Context _context;
        private HttpClient _client;
        private IConfiguration _config;
        public DriverService(F1Context context, HttpClient client, IConfiguration config)
        {
            _config = config;
            _context = context;
            _client = client;
        }
        public Task Create(Driver entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Driver entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Driver>> GetAll()
        {
            try
            {
                var drivers = await _context.Drivers.ToListAsync();
                if (!drivers.IsNullOrEmpty())
                {
                    return drivers;
                }
                else
                {
                    throw new Exception("Drivers Not Exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);
            }
          
            
        }

        public async Task<IEnumerable<CarDriverDto>> GetAllCardDrivers()
        {
           
            string url = _config["AppSettings:BaseUrl"] + "/api/Driver";
            Debug.Print(url + "hola");  
            var result = await _client.GetFromJsonAsync<IEnumerable<CarDriverDto>>(url);
          
            return result;
        }

        public Task<Driver?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> GetCardDriver(int id)
        {
            throw new NotImplementedException();
        }

       

        public Task UpdateAsync(Driver entity)
        {
            throw new NotImplementedException();
        }

        Task<CarDriverDto> IDriverService.GetCardDriver(int id)
        {
            throw new NotImplementedException();
        }
    }
}
