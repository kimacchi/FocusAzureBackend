namespace FocusApi.Models
{
    public class Activity
    {
        public int activityId { get; set; }
        public string? activityName { get; set; }
        public int userId { get; set; }
        public string? description { get; set; }
        public string? activityTime { get; set; }
    }
}