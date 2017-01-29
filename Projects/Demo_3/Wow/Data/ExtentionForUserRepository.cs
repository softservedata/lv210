using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var adminUser = users.FirstOrDefault(user => user.GetIsAdmin());
            return adminUser;
        }

        public static IUser GetStudent(this IList<IUser> users)
        {
            var studentUser = users.FirstOrDefault(user => user.GetIsStudent());
            return studentUser;
        }

        public static IUser GetTeacher(this IList<IUser> users)
        {
            var teacherUser = users.FirstOrDefault(user => user.GetIsTeacher());
            return teacherUser;
        }

        //public static object[] ToMultiArray(object argList) < --------------------- origin / del
        //{
        //    IList list = ((IList)argList);
        //    object[] array = new object[list.Count];
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        array[i] = new object[] { list[i] };
        //    }
        //    return array;
        //}

        //public static object[] ToMultiArray(object source, object argList) // < ---------------------- del
        //{
        //    IList list = ((IList)argList);
        //    object[] array = new object[list.Count];
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        array[i] = new object[] { source, list[i] };
        //    }
        //    return array;
        //}
    }
}
