using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace stajproje2.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Doviz> Doviz { get; set; }
        public virtual DbSet<Kullanıcı> Kullanıcı { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Olay> Olay { get; set; }
        public virtual DbSet<Satıs> Satıs { get; set; }
        public virtual DbSet<Subeler> Subeler { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ziyaretler> Ziyaretler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doviz>()
                .Property(e => e.dovizname)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanıcı>()
                .Property(e => e.k_username)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanıcı>()
                .Property(e => e.k_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanıcı>()
                .Property(e => e.k_password)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanıcı>()
                .Property(e => e.k_isim)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanıcı>()
                .Property(e => e.k_tel)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanıcı>()
                .Property(e => e.k_Rol)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanıcı>()
                .HasMany(e => e.Satıs)
                .WithOptional(e => e.Kullanıcı)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Kullanıcı>()
                .HasMany(e => e.Ziyaretler)
                .WithOptional(e => e.Kullanıcı)
                .HasForeignKey(e => e.z_user_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Musteri>()
                .Property(e => e.m_ad)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.m_tel)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.m_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.m_sirket)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Satıs)
                .WithOptional(e => e.Musteri)
                .HasForeignKey(e => e.m_fk_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Olay>()
                .Property(e => e.olay_durum)
                .IsUnicode(false);

            modelBuilder.Entity<Olay>()
                .Property(e => e.olay_islem)
                .IsUnicode(false);

            modelBuilder.Entity<Olay>()
                .HasMany(e => e.Ziyaretler)
                .WithOptional(e => e.Olay)
                .HasForeignKey(e => e.z_olay_id);

            modelBuilder.Entity<Satıs>()
                .Property(e => e.sat_urun)
                .IsUnicode(false);

            modelBuilder.Entity<Subeler>()
                .Property(e => e.sube_ad)
                .IsUnicode(false);

            modelBuilder.Entity<Subeler>()
                .Property(e => e.sube_il)
                .IsUnicode(false);

            modelBuilder.Entity<Subeler>()
                .Property(e => e.sube_tel)
                .IsUnicode(false);

            modelBuilder.Entity<Subeler>()
                .Property(e => e.sube_adres)
                .IsUnicode(false);

            modelBuilder.Entity<Subeler>()
                .HasMany(e => e.Ziyaretler)
                .WithOptional(e => e.Subeler)
                .HasForeignKey(e => e.sube_fk_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Ziyaretler>()
                .Property(e => e.z_durum)
                .IsUnicode(false);

            modelBuilder.Entity<Ziyaretler>()
                .Property(e => e.z_not)
                .IsUnicode(false);

            modelBuilder.Entity<Ziyaretler>()
                .Property(e => e.z_ismi)
                .IsUnicode(false);
        }
    }
}
