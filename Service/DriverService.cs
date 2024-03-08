using AutoMapper;
using f1api.DTOs;
using f1api.Models;
using f1api.Service.IService;
using F1api.Repository;
using F1api.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace f1api.Service
{
    public class DriverService : IDriverService
    {
        private F1Context _context;
        private HttpClient _client;
        private IConfiguration _config;
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(F1Context context, HttpClient client, IConfiguration config, IDriverRepository driverRepository , IMapper mapper)
        {
            _config = config;
            _context = context;
            _client = client;
            _driverRepository = driverRepository;
            _mapper = mapper;
        }
        public async  Task<Driver> Create(Driver entity)
        {
            await _driverRepository.Add(entity);
            await _driverRepository.Save();
            return entity;
        }

        public async Task Delete(Driver entity)
        {
          var driverToDelete = await _driverRepository.GetById(entity.Id);
            if (driverToDelete != null)
            {
                await _driverRepository.Delete(entity);

              await  _driverRepository.Save();
            }
            else
            {
                throw new Exception("Driver Not Found");
            }
           
        }

        public async Task<IEnumerable<Driver>> GetAll()
        {
            try
            {
                var drivers = await _driverRepository.GetAll();
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

        public async Task<IEnumerable<CardDriverDto>> GetAllCardDrivers()
        {

            /* string url = _config["AppSettings:BaseUrl"] + "/api/Driver";
             Debug.Print(url + "hola");  
             var result = await _client.GetFromJsonAsync<IEnumerable<CardDriverDto>>(url);
           */
            var drivers = await _driverRepository.GetAll();
            var result =  _mapper.Map<IEnumerable<CardDriverDto>>(drivers);




            return result;
        }

        public  async Task<Driver?> GetById(int id)
        {
           var driverToGet= await _context.Drivers.FindAsync(id);
            if (driverToGet != null)
            {
                return driverToGet;
            }
            else
            {
                throw new Exception("Driver Not Found");
            }
        }

        public Task<CardDriverDto> GetCardDriver(int id)
        {
            throw new NotImplementedException();
        }

       

        public async Task<Driver> Update(Driver entity, int id)
        {
            var driverToUpdate = await _context.Drivers.FindAsync(id);
            Debug.Print(JsonSerializer.Serialize(driverToUpdate));
          
            
            if (driverToUpdate != null)
            {
                driverToUpdate.Name = entity.Name ?? driverToUpdate.Name;
                driverToUpdate.Nationality = entity.Nationality ?? driverToUpdate.Nationality;
                driverToUpdate.DateOfBirth = entity.DateOfBirth != null ? entity.DateOfBirth : driverToUpdate.DateOfBirth;
                driverToUpdate.Height = entity.Height ??  driverToUpdate.Height;
                driverToUpdate.Weight = entity.Weight ?? driverToUpdate.Weight;
                driverToUpdate.DebutYear = entity.DebutYear ?? driverToUpdate.DebutYear;
                driverToUpdate.CurrentTeam = entity.CurrentTeam ?? driverToUpdate.CurrentTeam;
                driverToUpdate.CarNumber = entity.CarNumber ?? driverToUpdate.CarNumber;
                driverToUpdate.DebutTeam = entity.DebutTeam ?? driverToUpdate.DebutTeam;
               

                
                await _context.SaveChangesAsync();
                driverToUpdate.Id= id;
                
                return driverToUpdate;
            }
            else
            {
                throw new Exception("Driver Not Found");
            }
           
        }

      
    }
}
