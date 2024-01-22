using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using UserManagment.Core.Entities;

namespace UserManagment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public DbSet<Layout> Layouts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder
                .Entity<Layout>()
                .HasKey(ck => new { ck.UserLogin, ck.InterfaceType });

        }
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<ApplicationDbContext>(options => {
        //        options.UseSqlite(Configuration.GetConnectionString("MyConnection"));
        //    });
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var configuration = new ConfigurationBuilder();
            //  configuration.SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite("Data Source=Database/UserManagmentDatabase.db");
        }


    }
}
