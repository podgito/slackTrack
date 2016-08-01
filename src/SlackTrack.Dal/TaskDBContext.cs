using SlackTrack.Dal.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SlackTrack.Dal
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext() : base("TaskDBContext")
        {
        }

        public DbSet<SlackTeam> Teams { get; set; }
        public DbSet<SlackUser> Users { get; set; }
        public DbSet<SlackTaskCategory> Categories { get; set; }
        public DbSet<SlackTaskLogItem> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}