namespace NovelWebsite.Extensions
{
    public class DateTimeExtension
    {
        public static string TimeSpan(DateTime dateTime)
        {

            TimeSpan timeSinceDate = DateTime.Now - dateTime;

            if (timeSinceDate.TotalDays >= 365) // trên 1 năm
            {
                return $"{Convert.ToInt32(timeSinceDate.TotalDays/ 365)} năm trước";
            }
            else if (timeSinceDate.TotalDays >= 30) // trên 1 tháng
            {
                return $"{Convert.ToInt32(timeSinceDate.TotalDays/ 30)} tháng trước";
            }
            else if (timeSinceDate.TotalDays >= 2) // 2 ngày
            {
                return $"{Convert.ToInt32(timeSinceDate.TotalDays)} hôm trước";
            }
            else if (timeSinceDate.TotalDays >= 1) // 1 ngày
            {
                return "Hôm qua";
            }
            else if (timeSinceDate.TotalHours >= 1)
            {
                return $"{Convert.ToInt32(timeSinceDate.TotalHours)} tiếng trước";
            }
            else if (timeSinceDate.TotalMinutes >= 1)
            {
                return $"{Convert.ToInt32(timeSinceDate.TotalHours)} phút trước";
            }
            else if (timeSinceDate.TotalSeconds >= 1)
            {
                return $"{Convert.ToInt32(timeSinceDate.TotalHours)} giây trước";
            }
            else // ngày hôm nay
            {
                return "Vừa xong";
            }
        }
    }
}
