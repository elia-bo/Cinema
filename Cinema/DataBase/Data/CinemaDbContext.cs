using Cinema.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataBase.Data
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<Biglietto> Biglietti { get; set; } = null;
        public DbSet<Film> Film { get; set; } = null;
        public DbSet<Sala> Sale { get; set; } = null;
        public DbSet<Spettatore> Spettatori { get; set; } = null;

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

            biglietto
                .HasOne(b => b.Film)
                .WithMany(f => f.Biglietti)
                .HasForeignKey(b => b.IdFilm);

            biglietto.HasData(new Biglietto[] {
                new Biglietto {
                    Id = 1,
                    Fila = 'A',
                    Posto = 5,
                    Prezzo = 20
                },
            new Biglietto {
                    Id = 2,
                    Fila = 'G',
                    Posto = 7,
                    Prezzo = 13
                },
            new Biglietto {
                    Id = 3,
                    Fila = 'D',
                    Posto = 2,
                    Prezzo = 17
                },
            });

            var film = modelBuilder.Entity<Film>();
            film.HasKey(f => f.Id);
            film.Property(f => f.TitoloFilm).HasMaxLength(50).IsRequired();

            film
                .HasOne(f => f.Sala)
                .WithOne(s => s.FilmInCorso)
                .HasForeignKey<Sala>(s => s.IdFilmInCorso);

            film.HasData(new Film[]
            {
                new Film
                {
                    Id = 1,
                    TitoloFilm = "Matrix",
                    Durata = 200,
                    Autore = "Cesare",
                    Produttore = "Alberto",
                    Genere = GenereFilm.Fantascienza
                },
                new Film
                {
                    Id = 2,
                    TitoloFilm = "Top Gun",
                    Durata = 150,
                    Autore = "Gino",
                    Produttore = "Giacomo",
                    Genere = GenereFilm.Azione
                },
                new Film
                {
                    Id = 3,
                    TitoloFilm = "Scream",
                    Durata = 190,
                    Autore = "Luca",
                    Produttore = "Paolo",
                    Genere = GenereFilm.Horror
                }
            });

            var sala = modelBuilder.Entity<Sala>();
            sala.HasKey(s => s.Id);
            sala.Property(s => s.MaxNumSpettatori).IsRequired();

            sala.HasData(new Sala[]
            {
                new Sala
                {
                    Id =1,
                    MaxNumSpettatori = 200
                },
                new Sala
                {
                    Id =2,
                    MaxNumSpettatori = 300
                }
            });

            var spettatore = modelBuilder.Entity<Spettatore>();
            spettatore.HasKey(s => s.Id);
            spettatore.Property(s => s.Nome).HasMaxLength(50).IsRequired();
            spettatore.Property(s => s.Cognome).HasMaxLength(50).IsRequired();
            spettatore.Property(s => s.DataNascita).HasColumnType("date").IsRequired();

            spettatore
                .HasOne(s => s.Biglietto)
                .WithOne(b => b.Spettatore)
                .HasForeignKey<Spettatore>(s => s.IdBiglietto);

            spettatore.HasData(new Spettatore[]
            {
                new Spettatore
                {
                    Id = 1,
                    Nome = "Alberto",
                    Cognome = "Alby",
                    DataNascita = new System.DateTime(2014,2,25),
                    Eta = 8,
                    Maggiorenne = false
                },
                new Spettatore
                {
                    Id = 2,
                    Nome = "Mario",
                    Cognome = "Gallo",
                    DataNascita = new System.DateTime(1980,4,21),
                    Eta = 42,
                    Maggiorenne = true
                },
                new Spettatore
                {
                    Id = 3,
                    Nome = "Giacomo",
                    Cognome = "Gallo",
                    DataNascita = new System.DateTime(1970,2,25),
                    Eta = 52,
                    Maggiorenne = true
                }
            });

            var assegnamento = modelBuilder.Entity<Assegnamento>();
            assegnamento.HasKey(a => a.Id);
            assegnamento.Property(a => a.IdSpettatore).IsRequired();
            assegnamento.Property(a => a.IdSala).IsRequired();

            assegnamento
                .HasOne(a => a.Sala)
                .WithMany(s => s.Assegnamenti)
                .HasForeignKey(a => a.IdSala);

            assegnamento
                .HasOne(a => a.Spettatore)
                .WithMany(s => s.Assegnamenti)
                .HasForeignKey(a => a.IdSpettatore);
        }

        public DbSet<Cinema.Domain.Assegnamento> Assegnamento { get; set; }
    }
}
