namespace f1api.Service.IService.IActions
{
    public interface IUpdate <Entity> where Entity : class
    {
        Task<Entity> Update(Entity entity,int id);
    }
}
