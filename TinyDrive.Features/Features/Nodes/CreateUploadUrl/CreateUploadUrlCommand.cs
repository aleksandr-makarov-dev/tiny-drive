using MediatR;
using ErrorOr;

namespace TinyDrive.Features.Features.Nodes.CreateUploadUrl;

public sealed record CreateUploadUrlCommand(
	string FileName,
	long FileSizeBytes,
	string ContentType,
	Guid? ParentFolderId) : IRequest<ErrorOr<CreateUploadUrlResponse>>;
