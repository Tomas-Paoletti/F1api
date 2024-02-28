namespace f1api.Service.IService.IActions
{
    public interface ICreate<Entity> where Entity : class
    {
        Task<Entity> Create(Entity entity);
    }
}
