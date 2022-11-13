namespace LazyCacheWithNet
{
    internal static class LongTaskAndResources
    {

        public static List<string> MyListe { get; set; } = new List<string>() { "val1", "val2", "val3" };

        internal static async Task<List<string>> GetLongTask()
        {
            await Task.Delay(5000);
            return MyListe;
        }

        internal static void AddItem(string value)
        {
            MyListe.Add(value);
        }
    }
}
