namespace f1api.Service.IService.IActions
{
    public interface IDelete<Entity> where Entity : class
    {
        Task Delete(Entity entity);
    }
}
