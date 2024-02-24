namespace f1api.Service.IService.IActions
{
    public interface IUpdate <Entity> where Entity : class
    {
        Task UpdateAsync(Entity entity);
    }
}
