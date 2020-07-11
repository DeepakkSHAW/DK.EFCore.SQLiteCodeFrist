using DK.EFCore.SQLiteCodeFrist.Data;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DK.EFCore.SQLiteCodeFrist.DataModel;

namespace DK.EFCore.SQLiteCodeFrist
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("SQLite CodeFrist Approach");

            try
            {
                var newAMC = new AMC() { AMCTitle = "Parag Parikh long term equity fund" };

                /* To read configuration from json file, add Package: Microsoft.Extensions.Configuration.Json */
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("AppConfig.json", optional: false, reloadOnChange: true);


                var configuration = builder.Build();
                Debug.WriteLine(configuration.GetConnectionString("SqliteDB"));

                /*Using Repository Pattern to Fetch data from DB*/
                var services = new ServiceCollection();
                
                services.AddDbContext<AMCDBContext>(options => options.UseSqlite(configuration.GetConnectionString("SqliteDB"), options => options.MaxBatchSize(512)));
                services.AddDbContext<AMCDBContext>(options => options.EnableSensitiveDataLogging());

                /*Adding AMC implementation to Dependency Injection*/
                services.AddTransient<Data.Services.IAMCData, Data.Services.AMCData>();

                /*Fetching AMC implementation from DI*/
                var provider = services.BuildServiceProvider();
                var quary = provider.GetService<Data.Services.IAMCData>();

                /*Write Data from Database*/
                var IsDone = quary.AddAMCSAsync(newAMC);

                /*Read Data from Database*/
                var rec = await quary.GetAMCSAsync();
                foreach (var item in rec)
                {
                    Console.WriteLine($"{item.AMCId}  -  {item.AMCTitle}  -  {item.InDate}");
                }

                /* Direct fetching data from DBContext */
                //var mf_amc = new Data.Services.AMCData();
                //var amc = await mf_amc.GetAMCSAsync();
                //foreach (var item in amc)
                //{
                //    Console.WriteLine(item.AMCName);
                //}

                //using (var db = new AMCDBContext(configuration.GetConnectionString("SqliteDB")))
                //{
                //    var o = await db.AMCs.ToListAsync();

                //    foreach (var item in o)
                //    {
                //        Console.WriteLine($"{item.AMCId}  -  {item.AMCTitle}");
                //    }
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
