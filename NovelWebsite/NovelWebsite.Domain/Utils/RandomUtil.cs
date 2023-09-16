namespace NovelWebsite.NovelWebsite.Domain.Utils
{
    public static class RandomUtil<T>
    {
        public static T GetRandom(IEnumerable<T>list, int length)
        {
            Random r = new Random();
            int rand = r.Next(length);
            return list.ElementAt(rand);
        }
    }
}
