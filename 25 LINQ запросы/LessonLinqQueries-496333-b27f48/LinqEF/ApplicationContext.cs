using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public ApplicationContext() : base()
    {
        /*Database.EnsureDeleted();
        Database.EnsureCreated();
        this.SaveChanges();*/
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("data source=localhost;initial catalog=Users;user=sa;password=********;App=EntityFramework;TrustServerCertificate=True");
    } 
}