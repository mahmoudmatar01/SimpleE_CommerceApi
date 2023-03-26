using EShopeApi.Models;
using EShopeApi.SeedData;
using Microsoft.EntityFrameworkCore;

namespace EShopeApi.DBContext
{
    public class DataContext:DbContext
    {

        //public constructor 
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        //Convert EntitySet to table into Database 
        public DbSet<Products> Products { get; set; }
        public DbSet<UserRegister> UserRegister { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }

        //override OnModelCreating method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedProduct();
        }

        //override OnConfiguring method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            var constring = config.GetConnectionString("MyConnection");
            optionsBuilder.UseSqlServer(constring);

        }


    }
}
