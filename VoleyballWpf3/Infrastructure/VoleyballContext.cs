using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using VoleyballWpf3.Models;

namespace VoleyballWpf3.Infrastructure
{
    public class VoleyballContext : DbContext
    {
        public DbSet<People> People { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<Hotel> Hotels { get; set; }
        //public DbSet<HotelNumber> HotelNumbers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Team_Composition> TeamCompositions { get; set; }
        //public DbSet<DistributionHotel> DistributionHotels { get; set; }
        public DbSet<Position_On_Field> PositionsOnField { get; set; }
        //public DbSet<TrainingTime> TrainingTimes { get; set; }
        //public DbSet<Hall> Halls { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Game> Games { get; set; }
        //public DbSet<Tournament> Tournaments { get; set; }
        //public DbSet<Ticket> Tickets { get; set; }
        //public DbSet<TicketSale> TicketSales { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Judging_Role> JudgingRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=voleyb_db;Trusted_Connection=True;TrustServerCertificate=True;"
                );


        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связи один-ко-многим между People и TeamCompositions
            modelBuilder.Entity<Team_Composition>()
                .HasOne(tc => tc.People)
                .WithMany(p => p.Team_Compositions)
                .HasForeignKey(tc => tc.PeopleSportId);

            // Настройка связи один-ко-многим между Team и TeamCompositions
            modelBuilder.Entity<Team_Composition>()
                .HasOne(tc => tc.Team)
                .WithMany(t => t.Team_Compositions)
                .HasForeignKey(tc => tc.TeamId);

            // Конфигурация для People и Role
            modelBuilder.Entity<People>()
                .HasOne(p => p.Role)
                .WithMany(r => r.People)
                .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<Team_Composition>()
                .HasOne(tc => tc.People)
                .WithMany(p => p.Team_Compositions)
                .HasForeignKey(tc => tc.PeopleSportId);

            modelBuilder.Entity<Team_Composition>()
                .HasOne(tc => tc.Position_On_Field)
                .WithMany(pf => pf.Team_Compositions)
                .HasForeignKey(tc => tc.PositionOnFieldId);

            // Конфигурация для Game
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Team_1)
                .WithMany(t => t.GamesAsTeam_1)
                .HasForeignKey(g => g.Team_1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Team_2)
                .WithMany(t => t.GamesAsTeam_2)
                .HasForeignKey(g => g.Team_2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Stage)
                .WithMany(s => s.Games)
                .HasForeignKey(g => g.StageId);

            //modelBuilder.Entity<Game>()
            //    .HasOne(g => g.Hall)
            //    .WithMany(h => h.Games)
            //    .HasForeignKey(g => g.HallId);

            //modelBuilder.Entity<Game>()
            //    .HasOne(g => g.Tournament)
            //    .WithMany(t => t.Games)
            //    .HasForeignKey(g => g.TournamentId);

            // Конфигурация для Judge
            modelBuilder.Entity<Judge>()
                .HasOne(j => j.Game)
                .WithMany(g => g.Judges)
                .HasForeignKey(j => j.GameId);

            modelBuilder.Entity<Judge>()
                .HasOne(j => j.People)
                .WithMany(p => p.Judges)
                .HasForeignKey(j => j.People_JudgeId);

            modelBuilder.Entity<Judge>()
                .HasOne(j => j.Judging_Role)
                .WithMany(jr => jr.Judges)
                .HasForeignKey(j => j.Judging_RoleId);

            // Конфигурация для TicketSale
            //modelBuilder.Entity<TicketSale>()
            //    .HasOne(ts => ts.Ticket)
            //    .WithMany(t => t.TicketSales)
            //    .HasForeignKey(ts => ts.TicketId);

            //modelBuilder.Entity<TicketSale>()
            //    .HasOne(ts => ts.Game)
            //    .WithMany(g => g.TicketSales)
            //    .HasForeignKey(ts => ts.GameId);

            //modelBuilder.Entity<TicketSale>()
            //    .HasOne(ts => ts.People)
            //    .WithMany(p => p.TicketSales)
            //    .HasForeignKey(ts => ts.PeopleId);

            //// Конфигурация для TrainingTime
            //modelBuilder.Entity<TrainingTime>()
            //    .HasOne(tt => tt.Hall)
            //    .WithMany(h => h.TrainingTimes)
            //    .HasForeignKey(tt => tt.HallId);

            //modelBuilder.Entity<TrainingTime>()
            //    .HasOne(tt => tt.Team)
            //    .WithMany(t => t.TrainingTimes)
            //    .HasForeignKey(tt => tt.TeamId);

            // Конфигурация для DistributionHotel
            //modelBuilder.Entity<DistributionHotel>()
            //    .HasOne(dh => dh.TeamComposition)
            //    .WithMany(tc => tc.DistributionHotels)
            //    .HasForeignKey(dh => dh.TeamCompositionId);

            //modelBuilder.Entity<DistributionHotel>()
            //    .HasOne(dh => dh.Tournament)
            //    .WithMany(t => t.DistributionHotels)
            //    .HasForeignKey(dh => dh.TournamentId);

            //modelBuilder.Entity<DistributionHotel>()
            //    .HasOne(dh => dh.HotelNumber)
            //    .WithMany(hn => hn.DistributionHotels)
            //    .HasForeignKey(dh => dh.HotelNumberId);

            //// Конфигурация для HotelNumber
            //modelBuilder.Entity<HotelNumber>()
            //    .HasOne(hn => hn.Hotel)
            //    .WithMany(h => h.HotelNumbers)
            //    .HasForeignKey(hn => hn.HotelId);
        }

        #endregion
    }
}
