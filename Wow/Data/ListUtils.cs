using System.Collections;

namespace Wow.Data
{
    public static class ListUtils
    {
        public static object[] ToMultiArray(object argList)
        {
            IList list = ((IList)argList);
            object[] array = new object[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                array[i] = new object[] { list[i] };
            }
            return array;
        }

        public static object[] ToMultiArray(object source, object argList)
        {
            IList list = ((IList)argList);
            object[] array = new object[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                array[i] = new object[] { source, list[i] };
            }
            return array;
        }
    }
}
