using Microsoft.EntityFrameworkCore;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.Efc;

public class WannabeRedditContext : DbContext {
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source = WannabeReddit.db");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
