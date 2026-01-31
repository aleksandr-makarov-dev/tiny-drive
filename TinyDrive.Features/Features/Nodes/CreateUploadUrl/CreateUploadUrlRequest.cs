namespace TinyDrive.Features.Features.Nodes.CreateUploadUrl;

public sealed record CreateUploadUrlRequest(
	string FileName,
	long FileSizeBytes,
	string ContentType,
	Guid? ParentFolderId);
