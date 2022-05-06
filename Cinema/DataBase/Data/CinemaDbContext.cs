using Cinema.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataBase.Data
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<Biglietto> Biglietti { get; set; } = null;
        public DbSet<Biglietto> Film { get; set; } = null;
        public DbSet<Biglietto> Sale { get; set; } = null;
        public DbSet<Biglietto> Spettatori { get; set; } = null;

        public CinemaDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var biglietto = modelBuilder.Entity<Biglietto>();
            biglietto.HasKey(b => b.Id);
            biglietto.Property(b => b.Fila).IsRequired();
            biglietto.Property(b => b.Posto).IsRequired();
            biglietto.Property(b => b.Prezzo).IsRequired();

            var film = modelBuilder.Entity<Film>();
            film.HasKey(f => f.Id);
            film.Property(f => f.TitoloFilm).HasMaxLength(50).IsRequired();

            var sala = modelBuilder.Entity<Sala>();
            sala.HasKey(s => s.Id);
            sala.Property(s => s.MaxNumSpettatori).IsRequired();

            sala
                .HasMany(s => s.Spettatori)
                .WithOne(p => p.Sala);

            sala
                .HasOne(s => s.FilmInCorso)
                .WithOne(f => f.Sala)
                .HasForeignKey<Sala>(s => s.IdFilmInCorso);

            var spettatore = modelBuilder.Entity<Spettatore>();
            spettatore.HasKey(s => s.Id);
            spettatore.Property(s => s.Nome).HasMaxLength(50).IsRequired();
            spettatore.Property(s => s.Cognome).HasMaxLength(50).IsRequired();
            spettatore.Property(s => s.DataNascita).IsRequired();

            spettatore
                .HasOne(s => s.Biglietto)
                .WithOne(b => b.Spettatore)
                .HasForeignKey<Spettatore>(s => s.IdBiglietto);
        }
    }
}
