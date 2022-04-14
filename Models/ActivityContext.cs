using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FocusApi.Models
{
    public class ActivityContext : DbContext
    {
        public ActivityContext(DbContextOptions<ActivityContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; } = null!;
    }
}