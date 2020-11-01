using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Entitys
{
    public partial class StarwarsContext : DbContext
    {
        public StarwarsContext()
        {
        }

        public StarwarsContext(DbContextOptions<StarwarsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crafts> Crafts { get; set; }
        public virtual DbSet<FilmToCraft> FilmToCraft { get; set; }
        public virtual DbSet<FilmToPeople> FilmToPeople { get; set; }
        public virtual DbSet<Films> Films { get; set; }
        public virtual DbSet<FilmsToSpecies> FilmsToSpecies { get; set; }
        public virtual DbSet<Peoples> Peoples { get; set; }
        public virtual DbSet<PersonToCraft> PersonToCraft { get; set; }
        public virtual DbSet<Planets> Planets { get; set; }
        public virtual DbSet<PlanetsToFilms> PlanetsToFilms { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<SpeciesToPeople> SpeciesToPeople { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Crafts>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK_Spaceships");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(50);

                entity.Property(e => e.CargoCapacity).HasColumnName("cargo_capacity");

                entity.Property(e => e.Consumables)
                    .IsRequired()
                    .HasColumnName("consumables")
                    .HasMaxLength(50);

                entity.Property(e => e.CostInCredits).HasColumnName("cost_in_credits");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Crew)
                    .IsRequired()
                    .HasColumnName("crew")
                    .HasMaxLength(50);

               entity.Property(e => e.Edited)
                    .HasColumnName("edited")
                    .HasColumnType("datetime");
                    

                entity.Property(e => e.HyperdriveRating).HasColumnName("hyperdrive_rating");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasColumnName("manufacturer")
                    .HasMaxLength(500);

                entity.Property(e => e.MaxAtmospheringSpeed).HasColumnName("max_atmosphering_speed");

                entity.Property(e => e.Mglt).HasColumnName("MGLT");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Passengers)
                    .IsRequired()
                    .HasColumnName("passengers")
                    .HasMaxLength(50);

                entity.Property(e => e.StarshipClass)
                    .IsRequired()
                    .HasColumnName("starship_class")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleType).HasMaxLength(10);
            });

            modelBuilder.Entity<FilmToCraft>(entity =>
            {
                entity.HasKey(e => new { e.CraftUrl, e.FilmUrl });

                entity.Property(e => e.CraftUrl).HasMaxLength(50);

                entity.Property(e => e.FilmUrl).HasMaxLength(50);
            });

            modelBuilder.Entity<FilmToPeople>(entity =>
            {
                entity.HasKey(e => new { e.FilmUrl, e.PeopleUrl });

                entity.Property(e => e.FilmUrl).HasMaxLength(50);

                entity.Property(e => e.PeopleUrl).HasMaxLength(50);

                entity.HasOne(d => d.FilmUrlNavigation)
                    .WithMany(p => p.FilmToPeople)
                    .HasForeignKey(d => d.FilmUrl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmToPeople_Films");

                entity.HasOne(d => d.PeopleUrlNavigation)
                    .WithMany(p => p.FilmToPeople)
                    .HasForeignKey(d => d.PeopleUrl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmToPeople_Peoples");
            });

            modelBuilder.Entity<Films>(entity =>
            {
                entity.HasKey(e => e.Url);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(50);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Director)
                    .IsRequired()
                    .HasColumnName("director")
                    .HasMaxLength(100);

               entity.Property(e => e.Edited)
                    .HasColumnName("edited")
                    .HasColumnType("datetime");
                   

                entity.Property(e => e.EpisodeId).HasColumnName("episode_id");

                entity.Property(e => e.OpeningCrawl)
                    .IsRequired()
                    .HasColumnName("opening_crawl")
                    .HasMaxLength(1000);

                entity.Property(e => e.Producer)
                    .IsRequired()
                    .HasColumnName("producer")
                    .HasMaxLength(100);

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("release_date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<FilmsToSpecies>(entity =>
            {
                entity.HasKey(e => new { e.FilmUrl, e.SpeciesUrl });

                entity.Property(e => e.FilmUrl).HasMaxLength(50);

                entity.Property(e => e.SpeciesUrl).HasMaxLength(50);
            });

            modelBuilder.Entity<Peoples>(entity =>
            {
                entity.HasKey(e => e.Url);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(50);

                entity.Property(e => e.BirthYear)
                    .HasColumnName("birth_year")
                    .HasMaxLength(50);

                entity.Property(e => e.EyeColor)
                    .HasColumnName("eye_color")
                    .HasMaxLength(200);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(50);

                entity.Property(e => e.HairColor)
                    .HasColumnName("hair_color")
                    .HasMaxLength(50);

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Homeworld)
                    .HasColumnName("homeworld")
                    .HasMaxLength(50);

                entity.Property(e => e.Mass).HasColumnName("mass");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.SkinColor)
                    .HasColumnName("skin_color")
                    .HasMaxLength(100);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime"); 

                 entity.Property(e => e.Edited)
                    .HasColumnName("edited")
                    .HasColumnType("datetime");
                   
       
            });

            modelBuilder.Entity<PersonToCraft>(entity =>
            {
                entity.HasKey(e => new { e.PersonUrl, e.CraftUrl });

                entity.Property(e => e.PersonUrl).HasMaxLength(50);

                entity.Property(e => e.CraftUrl).HasMaxLength(50);
            });

            modelBuilder.Entity<Planets>(entity =>
            {
                entity.HasKey(e => e.Url);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(50);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Diameter).HasColumnName("diameter");

               entity.Property(e => e.Edited)
                    .HasColumnName("edited")
                    .HasColumnType("datetime");
                   

                entity.Property(e => e.Gravity)
                    .IsRequired()
                    .HasColumnName("gravity")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.OrbitalPeriod).HasColumnName("orbital_period");

                entity.Property(e => e.Population)
                    .HasColumnName("population")
                    .HasMaxLength(50);

                entity.Property(e => e.RotationPeriod).HasColumnName("rotation_period");

                entity.Property(e => e.SurfaceWater).HasColumnName("surface_water");

                entity.Property(e => e.Terrain)
                    .IsRequired()
                    .HasColumnName("terrain")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PlanetsToFilms>(entity =>
            {
                entity.HasKey(e => new { e.PlanetUrl, e.FilmsUrl });

                entity.Property(e => e.PlanetUrl).HasMaxLength(50);

                entity.Property(e => e.FilmsUrl).HasMaxLength(50);

                entity.HasOne(d => d.FilmsUrlNavigation)
                    .WithMany(p => p.PlanetsToFilms)
                    .HasForeignKey(d => d.FilmsUrl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanetsToFilms_Films");

                entity.HasOne(d => d.PlanetUrlNavigation)
                    .WithMany(p => p.PlanetsToFilms)
                    .HasForeignKey(d => d.PlanetUrl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanetsToFilms_Planets");
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.HasKey(e => e.Url);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(50);

                entity.Property(e => e.AverageHeight).HasColumnName("average_height");

                entity.Property(e => e.AverageLifespan).HasColumnName("average_lifespan");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasColumnName("classification")
                    .HasMaxLength(50);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasColumnName("designation")
                    .HasMaxLength(50);

               entity.Property(e => e.Edited)
                    .HasColumnName("edited")
                    .HasColumnType("datetime");
                    

                entity.Property(e => e.EyeColors)
                    .HasColumnName("eye_colors")
                    .HasMaxLength(100);

                entity.Property(e => e.HairColors)
                    .HasColumnName("hair_colors")
                    .HasMaxLength(100);

                entity.Property(e => e.Homeworld)
                    .HasColumnName("homeworld")
                    .HasMaxLength(50);

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.SkinColors)
                    .HasColumnName("skin_colors")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SpeciesToPeople>(entity =>
            {
                entity.HasKey(e => new { e.SpeciesUrl, e.PeopleUrl });

                entity.Property(e => e.SpeciesUrl).HasMaxLength(50);

                entity.Property(e => e.PeopleUrl).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
