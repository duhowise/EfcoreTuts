using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SumariCoreApp.Domain;

namespace SumariCoreApp.Data
{
    public class SamuraiContext:DbContext
    {
        public static readonly LoggerFactory MyConsoleLoggerFactory=new LoggerFactory(
            new []{new ConsoleLoggerProvider((category, level)=>category==DbLoggerCategory.Database.Command.Name
                                                                &&level==LogLevel.Information,true)});
        //public SamuraiContext(DbContextOptions<SamuraiContext> options):base(options)
        //{
            
        //}

        public SamuraiContext()
        {
            
        }
        public DbSet<Samurai> Sumarais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyConsoleLoggerFactory).EnableSensitiveDataLogging()
                .UseSqlServer("Server=.; Database=sumariDb; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(sb => new {sb.SamuraiId, sb.BattleId});
        }
    }
}