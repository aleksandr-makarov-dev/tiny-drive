namespace TinyDrive.Features.Features.Nodes.GetFolderItems;

public sealed record FolderItem(
	Guid Id,
	string Name,
	bool IsFolder,
	string MaterializedPath,
	DateTime CreatedAtUtc,
	DateTime? LastModifiedAtUtc);
