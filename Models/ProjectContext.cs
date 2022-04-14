using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FocusApi.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; } = null!;
    }
}