using GP.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GP.Data.Context
{
    public class MeuContext : DbContext
    {
        public MeuContext (DbContextOptions options) : base( options )
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Patrimonio> Patrimonios { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly( typeof( MeuContext ).Assembly );

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany( e => e.GetForeignKeys() )) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating( modelBuilder );
        }

        //public override Task<int> SaveChangesAsync (CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where( entry => entry.Entity.GetType().GetProperty( "DataCadastro" ) != null ))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property( "DataCadastro" ).CurrentValue = DateTime.Now;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property( "DataCadastro" ).IsModified = false;
        //        }
        //    }

        //    return base.SaveChangesAsync( cancellationToken );
        //}
    }
}
