using f1api.DTOs;
using f1api.Models;

namespace f1api.Service.IService
{
    public interface IDriverService: IGenericService<Driver>
    {
        Task <IEnumerable<CardDriverDto>> GetAllCardDrivers ();
        Task <CardDriverDto> GetCardDriver (int id);
    }
}
