using f1api.Models;

namespace F1api.Repository.IRepository
{
    public interface IGenericRepository<Entity>
    {
        public Task<IEnumerable<Entity>> GetAll();
        public Task<Entity> GetById(int id);
        public Task Add(Entity entity);
        public void Update(Entity entity);
        public Task Delete(Entity entity);
        public Task Save();
        
    }
}
