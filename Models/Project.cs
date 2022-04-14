namespace FocusApi.Models
{
    public class Project
    {
        public int projectId { get; set; }
        public int userId { get; set; }
        public string? projectName { get; set; }
        public string? todoList { get; set; }

    }
}