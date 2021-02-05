using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicatif.Models
{
    // Classes de liaison et de mapping avec la BDD
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
            DbConfiguration.SetConfiguration(new SQLiteConfiguration());
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Ledger> Ledger { get; set; }

    }

    public class SQLiteConfiguration : DbConfiguration
    {
        public SQLiteConfiguration()
        {
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
        }
    }

    public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        private readonly ApplicationDbContext m_dbContext = new ApplicationDbContext(connectionString);

        public ApplicationDbContext Create()
        {
            return m_dbContext;
        }

    }
}
