using ErrorOr;
using MediatR;

namespace TinyDrive.Features.Features.Nodes.CreateFolder;

public sealed record CreateFolderCommand(string Name, Guid? ParentFolderId) : IRequest<ErrorOr<Guid>>;
