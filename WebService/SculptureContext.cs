namespace WebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SculptureContext : DbContext
    {
        public SculptureContext()
            : base("name=SculptureContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Damage> Damages { get; set; }
        public virtual DbSet<Inspection> Inspections { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Material_Type> Material_Type { get; set; }
        public virtual DbSet<Sculpture> Sculptures { get; set; }
        public virtual DbSet<Sculpture_Damage> Sculpture_Damage { get; set; }
        public virtual DbSet<Sculpture_Location> Sculpture_Location { get; set; }
        public virtual DbSet<Sculpture_Material> Sculpture_Material { get; set; }
        public virtual DbSet<Sculpture_Type> Sculpture_Type { get; set; }
        public virtual DbSet<Sculpture_Type_Linking> Sculpture_Type_Linking { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Damage>()
                .Property(e => e.Damage_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Damage>()
                .Property(e => e.Damage_Treatment)
                .IsUnicode(false);

            modelBuilder.Entity<Damage>()
                .HasMany(e => e.Sculpture_Damage)
                .WithRequired(e => e.Damage)
                .HasForeignKey(e => e.Damage_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inspection>()
                .Property(e => e.Inspection_Note)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.Material_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Sculpture_Material)
                .WithRequired(e => e.Material)
                .HasForeignKey(e => e.Material_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material_Type>()
                .Property(e => e.Material_Type1)
                .IsUnicode(false);

            modelBuilder.Entity<Material_Type>()
                .HasMany(e => e.Materials)
                .WithRequired(e => e.Material_Type)
                .HasForeignKey(e => e.Material_Type_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sculpture>()
                .Property(e => e.Sculpture_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture>()
                .Property(e => e.Sculpture_Placement)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture>()
                .Property(e => e.Sculpture_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture>()
                .Property(e => e.Sculpture_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture>()
                .Property(e => e.Sculpture_Inspection_Frequency)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture_Location>()
                .Property(e => e.Sculpture_City)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture_Location>()
                .Property(e => e.Sculpture_Lat)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sculpture_Location>()
                .Property(e => e.Sculpture_Long)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sculpture_Type>()
                .Property(e => e.Sculpture_Type1)
                .IsUnicode(false);

            modelBuilder.Entity<Sculpture_Type>()
                .HasMany(e => e.Sculpture_Type_Linking)
                .WithRequired(e => e.Sculpture_Type)
                .HasForeignKey(e => e.Sculpture_Type_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
