namespace MajeBud.Data
{
    using MajeBug.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DataContext : DbContext
    {
        public DataContext(): base("name=DataContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var bug = modelBuilder.Entity<Bug>();
            bug.HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            bug.Property(x => x.IsFixed).IsRequired();
            bug.Property(x => x.Title).HasMaxLength(120).IsRequired();
            bug.Property(x => x.Body).HasMaxLength(500).IsRequired();
            bug.Property(x => x.StepsToReproduce).HasMaxLength(250).IsOptional();
            bug.Property(x => x.Severity).IsRequired();
            //Relationships
            //Tracking
            bug.HasRequired(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById);
            bug.HasOptional(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModfiedById);

            //Concurrency managment
            bug.Property(x => x.RowVersion).IsConcurrencyToken();
            //Severity
            var user = modelBuilder.Entity<User>();
            user.HasKey(x => x.Id);
            user.Property(x => x.DisplayName).HasMaxLength(100);
            user.Property(x => x.CreatedAd).IsRequired();
        }

        public virtual DbSet<Bug> Bugs { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}