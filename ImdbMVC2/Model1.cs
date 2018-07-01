namespace ImdbMVC2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
