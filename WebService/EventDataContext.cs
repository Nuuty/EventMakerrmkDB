namespace WebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EventDataContext : DbContext
    {
        public EventDataContext()
            : base("name=EventDataContext1")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Event> Event { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
