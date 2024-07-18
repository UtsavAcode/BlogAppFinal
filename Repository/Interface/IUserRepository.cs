using BlogApp.Model.Domain;

namespace BlogApp.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> Save(User obj);
        Task<User> Get(int objId);
        Task<List<User>> Gets();
        Task<User> GetByEmailPassword(User user);
        Task<String> Delete(User obj);
    }
}
