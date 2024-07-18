using BlogApp.Model.Domain;
using BlogApp.Repository.Interface;

namespace BlogApp.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        public Task<string> Delete(User obj)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int objId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmailPassword(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> Gets()
        {
            throw new NotImplementedException();
        }

        public Task<User> Save(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
