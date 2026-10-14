namespace UberManagement.Repos.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int  id);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
