namespace NovelWebsite.Application.Utils
{
    public static class Randomizer<T>
    {
        public static T GetRandom(IEnumerable<T>list, int length)
        {
            if (length <= 0)
            {
                return default;
            }
            Random r = new Random();
            int rand = r.Next(length);
            return list.ElementAt(rand);
        }
    }
}
