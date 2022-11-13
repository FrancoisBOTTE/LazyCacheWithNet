namespace LazyCacheWithNetWithoutDI
{
    internal static class LongTaskAndResources
    {
        internal static async Task<List<string>> GetLongTask()
        {
            await Task.Delay(5000);
            return new List<string>() { "val1", "val2", "val3" };
        }
    }
}
