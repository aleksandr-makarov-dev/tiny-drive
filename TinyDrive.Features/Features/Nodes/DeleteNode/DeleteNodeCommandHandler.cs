using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TinyDrive.Domain.Entities;
using TinyDrive.Features.Common.Errors;
using TinyDrive.Infrastructure.Data;

namespace TinyDrive.Features.Features.Nodes.DeleteNode;

public sealed class DeleteNodeCommandHandler(
	ApplicationDbContext dbContext,
	ILogger<DeleteNodeCommandHandler> logger) : IRequestHandler<DeleteNodeCommand, ErrorOr<Success>>
{
	public async Task<ErrorOr<Success>> Handle(DeleteNodeCommand request, CancellationToken cancellationToken)
	{
		var node = await dbContext.Nodes.FirstOrDefaultAsync(x => x.Id == request.NodeId,
			cancellationToken: cancellationToken);

		// Check if Node exists
		if (node is null)
		{
			logger.LogWarning("Attempting to soft-delete a node upload but the node not found.");
			return NodeErrors.NodeNotFound(request.NodeId);
		}

		// If Node is marked for deletion don't do anything
		if (node.DeletedAtUtc != null)
		{
			return Result.Success;
		}

		var deletedAtUtc = DateTime.UtcNow;

		return await (node.IsFolder
			? MoveFolderToTrashAsync(node, deletedAtUtc, cancellationToken: cancellationToken)
			: MoveFileToTrashAsync(node, deletedAtUtc, cancellationToken: cancellationToken));
	}

	private async Task<ErrorOr<Success>> MoveFolderToTrashAsync(Node node, DateTime deletedAtUtc,
		CancellationToken cancellationToken)
	{
		await dbContext.Nodes
			.Where(x => x.MaterializedPath.StartsWith(node.MaterializedPath))
			.ExecuteUpdateAsync(
				it => it.SetProperty(x => x.DeletedAtUtc, deletedAtUtc)
					.SetProperty(x => x.IsDeleted, true),
				cancellationToken: cancellationToken);

		return Result.Success;
	}

	private async Task<ErrorOr<Success>> MoveFileToTrashAsync(Node node, DateTime deletedAtUtc,
		CancellationToken cancellationToken)
	{
		node.DeletedAtUtc = deletedAtUtc;
		node.IsDeleted = true;

		await dbContext.SaveChangesAsync(cancellationToken);

		return Result.Success;
	}
}
