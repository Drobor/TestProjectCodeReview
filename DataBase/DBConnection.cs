using Microsoft.EntityFrameworkCore;
namespace TestProject
{
    public class DBConnection : DbContext
    {
        /// <summary> The property that contains the Employees table </summary>
        public DbSet<Employees> Employees { get; set; }

        /// <summary> The property that contains the Leaders table </summary>
        public DbSet<Leaders> Leaders { get; set; }

        /// <summary> The property that contains the LeadersEmployees table </summary>
        public DbSet<LeadersEmployees> LeadersEmployees { get; set; }

        /// <summary> Connection string </summary>
        private string DbPath { get; }


        public DBConnection()
        {
            DbPath = @"B:\Progect\TestProject\Project.db";
        }
        //-----------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Method for creating database connections
        /// </summary>
        /// <param name="options">Connection parameters</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    }
}
