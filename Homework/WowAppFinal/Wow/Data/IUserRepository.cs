using System.Collections.Generic;

namespace Wow.Data
{
    public interface IUserRepository
    {
        IList<IUser> GetAll();
        int FindCountOfUsers();
    }
}