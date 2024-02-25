namespace f1api.Service.IService.IActions
{
    public interface IGet<Entity> where Entity : class
    {
        Task<List<Entity>> GetAll();
        Task<Entity?> GetById(int id);
    }
}
