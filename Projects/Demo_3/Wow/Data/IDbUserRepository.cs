using System.Collections.Generic;

namespace Wow.Data
{
    public interface IDbUserRepository
    {
        List<User> GetAll();
        int FindCountOfUsers();
    }
}