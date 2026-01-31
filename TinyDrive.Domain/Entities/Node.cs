using System.ComponentModel.DataAnnotations.Schema;
using TinyDrive.Domain.Common;
using TinyDrive.Domain.Enums;

namespace TinyDrive.Domain.Entities;

public sealed class Node : Entity
{
	public required string Name { get; init; }

	public string? Extension { get; init; }

	public long? Size { get; init; }

	public string? ContentType { get; init; }

	public UploadStatus? UploadStatus { get; set; }

	public bool IsFolder { get; init; }

	public Guid? ParentId { get; init; }

	public required string MaterializedPath { get; init; }

	public DateTime CreatedAtUtc { get; init; }

	public DateTime? LastModifiedAtUtc { get; init; }

	public DateTime? DeletedAtUtc { get; set; }

	public bool IsDeleted { get; set; }

	[NotMapped] public string DisplayName => string.IsNullOrEmpty(Extension) ? Name : $"{Name}.{Extension}";

	[NotMapped] public string ObjectKey => string.IsNullOrEmpty(Extension) ? Name : $"{Id}.{Extension}";
}
