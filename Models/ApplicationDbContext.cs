using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Ledger> Ledger { get; set; }

    }

    public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["BaseTest"].ConnectionString;
        private readonly ApplicationDbContext m_dbContext = new ApplicationDbContext(connectionString);

        public ApplicationDbContext Create()
        {
            return m_dbContext;
        }

    }
}
