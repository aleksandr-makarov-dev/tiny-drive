using ErrorOr;
using MediatR;

namespace TinyDrive.Features.Features.Nodes.DeleteNode;

public sealed record DeleteNodeCommand(Guid NodeId) : IRequest<ErrorOr<Success>>;
