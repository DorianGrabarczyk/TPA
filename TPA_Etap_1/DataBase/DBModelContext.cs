using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataBase.Models;

namespace DataBase
{
    public class DBModelContext : DbContext
    {
      
        public DBModelContext(string connection)
            : base(connection)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<DBAssemblyModel> Assemblies { get; set; }
        public DbSet<DBMethodModel> Methods { get; set; }
        public DbSet<DBNamespaceModel> Namespaces { get; set; }
        public DbSet<DBParameterModel> Parameters { get; set; }
        public DbSet<DBPropertyModel> Properties { get; set; }
        public DbSet<DBTypeModel> Types { get; set; }
        public DbSet<DBMessage> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<DatabaseTypeMetadata>()
                .HasMany<DatabasePropertyMetadata>(s => s.PropertiesL)
                .WithMany(c => c.TypesProperties)
                .Map(cs =>
                {
                    cs.MapLeftKey("TypeRefId");
                    cs.MapRightKey("PropertyRefId");
                    cs.ToTable("TypeProperty");
                });
            modelBuilder.Entity<DatabaseMethodMetadata>()
                .HasMany<DatabaseTypeMetadata>(s => s.GenericArgumentsL)
                .WithMany(c => c.MethodsL)
                .Map(cs =>
                {
                    cs.MapLeftKey("MethodRefId");
                    cs.MapRightKey("GenericArgumentsRefId");
                    cs.ToTable("MethodGenericArguments");
                });

            modelBuilder.Entity<DatabaseTypeMetadata>()
                .HasMany(x => x.NestedTypesL)
                .WithMany()
                .Map(x => x.ToTable("NestedTypes"));

            modelBuilder.Entity<DatabaseTypeMetadata>()
                .HasMany(x => x.ImplementedInterfacesL)
                .WithMany()
                .Map(x => x.ToTable("Implemented interfaces"));*/
        }
    }
}
