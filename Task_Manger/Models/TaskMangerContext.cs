using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Task_Manger.Models
{
    public class TaskMangerContext:DbContext
    {
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        public TaskMangerContext(DbContextOptions<TaskMangerContext> options):base(options) { }
        
    }
}
