namespace SearchTask
{
    public class Finder
    {
        public void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
        {
            start = end = 0;
            CheckSetValues(list, sum, ref start, ref end);
            ulong result;
            for (int i = 0; i < list.Count; i++)
            {
                result = 0;
                for (int j = i; j < list.Count; j++)
                {
                    if (result < sum) result += list[j];
                    if (result == sum && sum != 0)
                    {
                        start = i;
                        end = j + 1;
                        return;
                    }
                }
            }
        }

        private static void CheckSetValues(List<uint> list, ulong sum, ref int start, ref int end)
        {
            if (list == null)
            {
                throw new NullReferenceException("List reference not set to an instance of an object.");
            }
            if (list.Count == 0)
            {
                throw new InvalidOperationException("List contains no elements");
            }
            if (sum is 0 && list.Contains(0))
            {
                start = list.IndexOf(0);
                end = start++;
            }
        }
    }
}
