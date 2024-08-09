using Microsoft.EntityFrameworkCore;

namespace NorwegianRowingAssociation.Models;

public partial class NorwegianRowingAssociationContext : DbContext
{
	public NorwegianRowingAssociationContext() { }

	public NorwegianRowingAssociationContext(DbContextOptions<NorwegianRowingAssociationContext> options)
		: base(options) { }

	public virtual DbSet<Test> Tests { get; set; }

	public virtual DbSet<TestResult> TestResults { get; set; }

	public virtual DbSet<TestWeek> TestWeeks { get; set; }

	public virtual DbSet<User> Users { get; set; }

	public virtual DbSet<UserClass> UserClasses { get; set; }

	public virtual DbSet<UserClub> UserClubs { get; set; }

	public virtual DbSet<UserRole> UserRoles { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.UseCollation("utf8mb4_0900_ai_ci").HasCharSet("utf8mb4");

		modelBuilder.Entity<Test>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("tests");

			entity.HasIndex(e => e.Name, "name").IsUnique();

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Name).HasMaxLength(25).HasColumnName("name");
		});

		modelBuilder.Entity<TestResult>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("test_results");

			entity.HasIndex(e => e.TestId, "test_id");

			entity.HasIndex(e => e.TestWeekId, "test_week_id");

			entity.HasIndex(e => e.UserId, "user_id");

			entity.HasIndex(e => e.Time, "time").IsUnique();

			entity.Property(e => e.Id).HasColumnName("id");
			entity
				.Property(e => e.CreatedDate)
				.HasDefaultValueSql("CURRENT_TIMESTAMP")
				.HasColumnType("datetime")
				.HasColumnName("created_date");
			entity.Property(e => e.Score).HasColumnName("score");
			entity.Property(e => e.TestId).HasColumnName("test_id");
			entity.Property(e => e.TestWeekId).HasColumnName("test_week_id");
			entity.Property(e => e.UserId).HasColumnName("user_id");
			entity.Property(e => e.Time).HasMaxLength(25).HasColumnName("time");
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime").HasColumnName("updated_date");

			entity
				.HasOne(d => d.Test)
				.WithMany(p => p.TestResults)
				.HasForeignKey(d => d.TestId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("test_results_ibfk_1");

			entity
				.HasOne(d => d.TestWeek)
				.WithMany(p => p.TestResults)
				.HasForeignKey(d => d.TestWeekId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("test_results_ibfk_2");

			entity
				.HasOne(d => d.User)
				.WithMany(p => p.TestResults)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("test_results_ibfk_3");
		});

		modelBuilder.Entity<TestWeek>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("test_weeks");

			entity.HasIndex(e => e.Number, "number").IsUnique();

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Number).HasColumnName("number");
		});

		modelBuilder.Entity<User>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("users");

			entity.HasIndex(e => e.Email, "email").IsUnique();

			entity.HasIndex(e => e.UserClassId, "user_class_id");

			entity.HasIndex(e => e.UserClubId, "user_club_id");

			entity.HasIndex(e => e.UserRoleId, "user_role_id");

			entity.Property(e => e.Id).HasColumnName("id");
			entity
				.Property(e => e.CreatedDate)
				.HasDefaultValueSql("CURRENT_TIMESTAMP")
				.HasColumnType("datetime")
				.HasColumnName("created_date");
			entity.Property(e => e.Email).HasColumnName("email");
			entity.Property(e => e.FirstName).HasMaxLength(25).HasColumnName("first_name");
			entity.Property(e => e.ImageUrl).HasMaxLength(255).HasColumnName("image_url");
			entity.Property(e => e.LastName).HasMaxLength(25).HasColumnName("last_name");
			entity.Property(e => e.Password).HasMaxLength(255).HasColumnName("password");
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime").HasColumnName("updated_date");
			entity.Property(e => e.UserClassId).HasColumnName("user_class_id");
			entity.Property(e => e.UserClubId).HasColumnName("user_club_id");
			entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");
			entity.Property(e => e.YearOfBirth).HasColumnName("year_of_birth");

			entity
				.HasOne(d => d.UserClass)
				.WithMany(p => p.Users)
				.HasForeignKey(d => d.UserClassId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("users_ibfk_1");

			entity
				.HasOne(d => d.UserClub)
				.WithMany(p => p.Users)
				.HasForeignKey(d => d.UserClubId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("users_ibfk_2");

			entity
				.HasOne(d => d.UserRole)
				.WithMany(p => p.Users)
				.HasForeignKey(d => d.UserRoleId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("users_ibfk_3");
		});

		modelBuilder.Entity<UserClass>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("user_classes");

			entity.HasIndex(e => e.Name, "name").IsUnique();

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Name).HasMaxLength(25).HasColumnName("name");
		});

		modelBuilder.Entity<UserClub>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("user_clubs");

			entity.HasIndex(e => e.Name, "name").IsUnique();

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Name).HasMaxLength(30).HasColumnName("name");
		});

		modelBuilder.Entity<UserRole>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("user_roles");

			entity.HasIndex(e => e.Name, "name").IsUnique();

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Name).HasMaxLength(10).HasColumnName("name");
		});
	}
}
