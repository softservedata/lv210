using System.Collections.Generic;
using System.Linq;

namespace Wow.Data
{
    public static class ExtentionForUserRepository
    {
        public static object[] GetAllUsers(this IList<IUser> users)
        {
            object[] array = new object[users.Count];
            for (int i = 0; i < users.Count; i++)
            {
                array[i] = new object[] { users[i] };
            }
            return array;
        }

        public static IUser GetAdmin(this IList<IUser> users)
        {
            var adminUser = users.FirstOrDefault(user => user.IsAdmin());
            return adminUser;
        }

        public static IUser GetStudent(this IList<IUser> users)
        {
            var studentUser = users.FirstOrDefault(user => user.IsStudent());
            return studentUser;
        }

        public static IUser GetTeacher(this IList<IUser> users)
        {
            var teacherUser = users.FirstOrDefault(user => user.IsTeacher());
            return teacherUser;
        }
    }
}