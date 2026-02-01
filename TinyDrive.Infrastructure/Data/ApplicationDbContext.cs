using Microsoft.EntityFrameworkCore;
using TinyDrive.Domain.Entities;

namespace TinyDrive.Infrastructure.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
	: DbContext(options)
{
	public DbSet<Node> Nodes => Set<Node>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		var node = modelBuilder.Entity<Node>();

		node.HasKey(x => x.Id);

		node.Property(x => x.Name)
			.HasMaxLength(255)
			.IsRequired();

		node.Property(x => x.Extension)
			.HasMaxLength(25);

		node.Property(x => x.ContentType)
			.HasMaxLength(100);

		node.Property(x => x.IsFolder)
			.IsRequired();

		node.Property(x => x.CreatedAtUtc)
			.IsRequired();

		node.Property(x => x.MaterializedPath)
			.HasMaxLength(1024)
			.IsRequired();

		node.Property(x => x.IsDeleted)
			.HasDefaultValue(false)
			.IsRequired();

		node.HasMany<Node>()
			.WithOne()
			.HasForeignKey(x => x.ParentId)
			.OnDelete(DeleteBehavior.Restrict);

		node.HasIndex(x => new
			{
				x.ParentId,
				x.Name,
				x.Extension,
				x.IsFolder,
				x.IsDeleted
			})
			.IsUnique();

		node.HasIndex(x => x.MaterializedPath);

		node.HasQueryFilter(x => !x.IsDeleted);
	}
}
