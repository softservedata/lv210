namespace HW_3_3
{
    public class MethodsForIntArr
    {
        public bool IsPositiveInt(int[] arr, int arrCounter)
        {
            bool isPositive = true;

            for (int i = 0; i < arrCounter; i++)
            {
                if ((arr[i] <= 0))
                {
                    isPositive = false;
                    break;
                }
            }
            return isPositive;
        }

        public int IntArrayElementsSum(int[] arr, int arrCounter)
        {
            int arrElemeSum = 0;

            for (int i = 0; i < arr[arrCounter]; i++)
            {
                arrElemeSum += arr[i];
            }
            return arrElemeSum;
        }

        public int IntArrayElementsProduct(int[] arr, int arrCounter)
        {
            int product = 1;

            for (int i = arr.Length - 1; i >= arrCounter; i--)
            {
                product *= arr[i];
            }
            return product;
        }
    }
}
