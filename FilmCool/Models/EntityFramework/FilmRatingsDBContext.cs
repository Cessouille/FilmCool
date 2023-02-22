using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace FilmCool.Models.EntityFramework
{
    public partial class FilmRatingsDBContext : DbContext
    {
        public FilmRatingsDBContext()
        {
        }

        public FilmRatingsDBContext(DbContextOptions<FilmRatingsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notation> Notations { get; set; }

        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

        public virtual DbSet<Film> Films { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres; password=postgres;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.UtilisateurId })
                    .HasName("pk_not");

                entity.HasOne(d => d.FilmNote).WithMany(p => p.NotesFilm)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_not_flm");

                entity.HasOne(d => d.UtilisateurNotant).WithMany(p => p.NotesUtilisateur)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_not_utl");

                entity.HasCheckConstraint("ck_note", "not_note between 0 and 5");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(b => b.UtilisateurId).HasName("pk_utl");

                entity.Property(b => b.Pays).HasDefaultValue("France");

                entity.Property(b => b.DateCreation).IsRequired().HasDefaultValueSql("now()");

                entity.HasIndex(b => b.Mail).IsUnique();

                entity.Property(b => b.Mobile).HasMaxLength(10).IsFixedLength();

                entity.Property(b => b.CodePostal).HasMaxLength(5).IsFixedLength();

                entity.Property(b => b.DateCreation).HasColumnType("date");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(b => b.FilmId).HasName("pk_flm");

                entity.Property(b => b.Duree).HasColumnType("numeric(3,0)");

                entity.Property(b => b.DateSortie).HasColumnType("date");
            });

                OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
