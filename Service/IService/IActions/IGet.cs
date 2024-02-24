namespace f1api.Service.IService.IActions
{
    public interface IGet<Entity> where Entity : class
    {
        Task<List<Entity>> Get();
        Task<Entity?> GetById(int id);
    }
}
