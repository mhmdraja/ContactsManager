using SMEasy.Domain.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
 

namespace SMEasy.Data
{
    public partial class ContactsManagerDbContext  : DbContext
    {
        public ContactsManagerDbContext()
        {
            this.Configuration.ProxyCreationEnabled = false; 
        }

        public ContactsManagerDbContext(string connectionString)
            : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            InitializeDecimal(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Contact> Contact { get; set; }

        public void InitializeDecimal(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(18, 3));
        }
    }
}
