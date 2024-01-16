using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EstatisticasFutebol.Data.Entities;

public partial class UfabcEcContext : DbContext
{
    public UfabcEcContext()
    {
    }

    public UfabcEcContext(DbContextOptions<UfabcEcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AwayProfile> AwayProfiles { get; set; }

    public virtual DbSet<HomeProfile> HomeProfiles { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<RoundMatches> RoundMatches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Password=ufabcec*2024;Persist Security Info=True;User ID=caiquecr;Initial Catalog=UfabcEC;Data Source=CTS1B147798\\SQLEXPRESS;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AwayProfile>(entity =>
        {
            entity.ToTable("AwayProfile");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DefeatOdd).HasDefaultValue(35f);
            entity.Property(e => e.DrawOdd).HasDefaultValue(35f);
            entity.Property(e => e.Team)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VictoryOdd).HasDefaultValue(30f);
        });

        modelBuilder.Entity<HomeProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HomeProfiles");

            entity.ToTable("HomeProfile");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DefeatOdd).HasDefaultValue(3f);
            entity.Property(e => e.DrawOdd).HasDefaultValue(35f);
            entity.Property(e => e.Team)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VictoryOdd).HasDefaultValue(35f);

            entity.HasOne(d => d.TeamNavigation).WithMany(p => p.HomeProfiles)
                .HasForeignKey(d => d.Team)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HomeProfile_Team");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("Team");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AwayProfileId).HasColumnName("AwayProfile_Id");
            entity.Property(e => e.ConversionRate).HasColumnName("Conversion_Rate");
            entity.Property(e => e.GoalsAgainst).HasColumnName("Goals_Against");
            entity.Property(e => e.GoalsDifference).HasColumnName("Goals_Difference");
            entity.Property(e => e.GoalsFor).HasColumnName("Goals_For");
            entity.Property(e => e.GoalsScored).HasColumnName("Goals_Scored");
            entity.Property(e => e.GroupLetter)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Group_Letter");
            entity.Property(e => e.HomeProfileId).HasColumnName("HomeProfile_Id");

            entity.HasOne(d => d.AwayProfile).WithMany(p => p.Teams)
                .HasForeignKey(d => d.AwayProfileId)
                .HasConstraintName("FK_Team_AwayProfile");

            entity.HasOne(d => d.HomeProfile).WithMany(p => p.Teams)
                .HasForeignKey(d => d.HomeProfileId)
                .HasConstraintName("FK_Team_HomeProfile");
        });


        modelBuilder.Entity<RoundMatches>(entity =>
        {
            entity.ToTable("RoundMatches");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Away_Team).HasMaxLength(50);
            entity.Property(e => e.Away_Score);
            entity.Property(e => e.Home_Team).HasMaxLength(50);
            entity.Property(e => e.Home_Score);
            entity.Property(e => e.Round_Number);
            entity.Property(e => e.Finished);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
