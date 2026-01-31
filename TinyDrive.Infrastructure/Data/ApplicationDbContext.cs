using Microsoft.EntityFrameworkCore;
using TinyDrive.Domain.Entities;

namespace TinyDrive.Infrastructure.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
	public DbSet<Node> Nodes => Set<Node>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Node>()
			.HasKey(x => x.Id);

		modelBuilder.Entity<Node>()
			.Property(x => x.Name)
			.HasMaxLength(255)
			.IsRequired();

		modelBuilder.Entity<Node>()
			.Property(x => x.Extension)
			.HasMaxLength(25);

		modelBuilder.Entity<Node>()
			.Property(x => x.ContentType)
			.HasMaxLength(100);

		modelBuilder.Entity<Node>()
			.Property(x => x.IsFolder)
			.IsRequired();

		modelBuilder.Entity<Node>()
			.Property(x => x.CreatedAtUtc)
			.IsRequired();

		modelBuilder.Entity<Node>()
			.HasMany<Node>()
			.WithOne()
			.HasForeignKey(x => x.ParentId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
