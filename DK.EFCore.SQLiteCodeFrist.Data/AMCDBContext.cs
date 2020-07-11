
using DK.EFCore.SQLiteCodeFrist.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

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
                /*This hard coded connection only required for EFCore migration purpose (need not be required at run time)*/
                var dbConnection = @"Data Source=..//DB//DemoMF.db";
                optionsBuilder.UseSqlite(dbConnection, options => options.MaxBatchSize(512));
                optionsBuilder.EnableSensitiveDataLogging();
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*declare the Primary key on each table*/
            modelBuilder.Entity<AMC>(entity => { entity.HasKey(p => p.AMCId); });
            modelBuilder.Entity<MutualFund>(entity => { entity.HasKey(p => p.MutualFundId); });

            /*declare the One-2-Many relationship*/
            modelBuilder.Entity<AMC>()
                .HasMany(m => m.MutualFunds)
                .WithOne(a => a.AMC);

            /*Insert a Dummy record on table creation (optional)*/
            modelBuilder.Entity<AMC>().HasData(
                new AMC() { AMCId = 1, AMCTitle = "OM test AMC" }
                );

        }
    }

}

