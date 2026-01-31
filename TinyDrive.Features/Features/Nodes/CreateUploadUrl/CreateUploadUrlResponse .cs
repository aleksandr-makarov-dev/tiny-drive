namespace TinyDrive.Features.Features.Nodes.CreateUploadUrl;

public sealed record CreateUploadUrlResponse(
	Guid FileId,
	string UploadUrl,
	DateTime ExpiresAtUtc,
	IReadOnlyDictionary<string, string> FormFields);
