using System.Collections.Generic;

namespace Wow.Data
{
    public interface IUserRepository
    {
        List<User> GetAll();
        int FindCountOfUsers();
    }
}