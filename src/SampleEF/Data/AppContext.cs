using SampleEF.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Data
{
    public class AppContext : DbContext
    {
        public DbSet<Administration> Administrations { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Item> Items { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                BaseModel baseModel = entry.Entity;
                entry.State = ConvertState(baseModel.State);
            }

            return base.SaveChanges();
        }

        public static EntityState ConvertState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Modified:
                    return EntityState.Modified;
                case State.Deleted:
                    return EntityState.Detached;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}
