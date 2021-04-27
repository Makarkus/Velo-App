using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeloAPP.Models
{
    public class BicycleAppDBContext : DbContext
    {
        public DbSet<Detail> Details { get; set; }
        public DbSet<Koleso> Kolesos { get; set; }
        public DbSet<Rama> Ramas { get; set; }


        public BicycleAppDBContext(DbContextOptions<BicycleAppDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
      
    }
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.HasOne(x => x.Ramas).WithMany(y => y.Details).HasForeignKey(z => z.RamaId);
        }
    }  
    public class KolesoConfiguration : IEntityTypeConfiguration<Koleso>
    {
        public void Configure(EntityTypeBuilder<Koleso> builder)
        {
            builder.HasOne(x => x.Ramas).WithMany(y => y.Kolesos).HasForeignKey(z => z.RamaId);
        }
    } 




}
