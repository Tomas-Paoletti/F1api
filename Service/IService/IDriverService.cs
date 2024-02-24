using f1api.Models;

namespace f1api.Service.IService
{
    public interface IDriverService: IGenericService<Driver>
    {
        Task <IEnumerable<Driver>> GetCardDriversAsync ();
    }
}
