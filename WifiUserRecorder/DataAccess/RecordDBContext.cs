using Microsoft.EntityFrameworkCore;
using WifiUserRecorder.Models;

namespace WifiUserRecorder.DataAccess
{
    public class RecordDBContext : DbContext
    {
        public virtual DbSet<Equipment> Equipments { get; set; }

        public virtual DbSet<WifiRecord> WifiRecords { get; set; }

        public virtual DbSet<RecordRelation> RecordRelations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            this.OnCustomConfiguring(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        protected virtual void OnCustomConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=Record.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WifiRecord>().HasKey(record => record.ID);
            modelBuilder.Entity<Equipment>().HasKey(equipment => equipment.ID);
            modelBuilder.Entity<RecordRelation>().HasKey(relation => relation.ID);

            modelBuilder.Entity<Equipment>()
                .HasMany(equipment => equipment.RecordRelations)
                .WithOne(relation => relation.Equipment)
                .HasForeignKey(relation => relation.EquipmentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WifiRecord>()
                .HasMany(record => record.RecordRelations)
                .WithOne(relation => relation.WifiRecord)
                .HasForeignKey(relation => relation.WifiRecordID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WifiRecord>().HasIndex(record => record.DateTime);
            modelBuilder.Entity<Equipment>().HasIndex(equipment => new { equipment.Mac, equipment.Name });

            base.OnModelCreating(modelBuilder);
        }
    }
}
