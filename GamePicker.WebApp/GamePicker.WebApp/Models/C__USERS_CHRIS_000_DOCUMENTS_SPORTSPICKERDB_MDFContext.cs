using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GamePicker.WebApp.Models
{
    public partial class C__USERS_CHRIS_000_DOCUMENTS_SPORTSPICKERDB_MDFContext : DbContext
    {
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Sport> Sport { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        public C__USERS_CHRIS_000_DOCUMENTS_SPORTSPICKERDB_MDFContext(DbContextOptions<C__USERS_CHRIS_000_DOCUMENTS_SPORTSPICKERDB_MDFContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).ValueGeneratedNever();

                entity.Property(e => e.GameDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.GameAwayTeam)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Game_AwayTeam");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.GameHomeTeam)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Game_WinningTeam");
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.Property(e => e.SportId).ValueGeneratedNever();

                entity.Property(e => e.SportTitle)
                    .IsRequired()
                    .HasColumnType("nchar(25)");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamId).ValueGeneratedNever();

                entity.Property(e => e.SportId).HasColumnName("SportID");

                entity.Property(e => e.TeamLocation)
                    .IsRequired()
                    .HasColumnType("nchar(30)");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasColumnType("nchar(30)");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Team_Sport");
            });
        }
    }
}