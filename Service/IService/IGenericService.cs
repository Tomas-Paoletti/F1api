using f1api.Service.IService.IActions;

namespace f1api.Service.IService
{
    public interface IGenericService<Entity>: IGet<Entity>,ICreate<Entity>,IUpdate<Entity>,IDelete<Entity> where Entity : class
    {

    }
}
