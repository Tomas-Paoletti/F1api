namespace f1api.Service.IService.IActions
{
    public interface IGet<Entity> where Entity : class
    {
        Task<IEnumerable<Entity>> GetAll();
        Task<Entity?> GetById(int id);
    }
}
