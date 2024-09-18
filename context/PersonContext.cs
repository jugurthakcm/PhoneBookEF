using System.Configuration;
using Microsoft.EntityFrameworkCore;
using phonebookef.models;

internal class PersonContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings.Get("defaultConnection"));
    }
}
