
using DK.EFCore.SQLiteCodeFrist.DataModel;
using Microsoft.EntityFrameworkCore;

namespace DK.EFCore.SQLiteCodeFrist.Data
{
    public class AMCDBContext : DbContext
    {
        
        public DbSet<AMC> AMCs { get; set; }

        //private readonly string connectionString;
        //public AMCDBContext(string connectionString) : base()
        //{
        //    this.connectionString = connectionString;
        //}
        public AMCDBContext() : base() { }
        public AMCDBContext(DbContextOptions<AMCDBContext> options) : base(options)
        {
            //Database.Migrate();
            Database.EnsureCreated();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var dbConnection = @"Data Source=C:\Deepak\Code\DotNet\DK.EFCore.SQLiteCodeFrist\DB\DemoMF.db";
                System.Diagnostics.Debug.WriteLine(dbConnection);

                optionsBuilder.UseSqlite(dbConnection, options => options.MaxBatchSize(512));
                optionsBuilder.EnableSensitiveDataLogging();
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AMC>(entity => { entity.HasKey(p => p.AMCId); });
        }
    }

}

