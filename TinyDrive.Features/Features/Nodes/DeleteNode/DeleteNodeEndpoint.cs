using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TinyDrive.Features.Common.Extensions;

namespace TinyDrive.Features.Features.Nodes.DeleteNode;

public sealed class DeleteNodeEndpoint : ICarterModule
{

	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPut("api/nodes/{nodeId:guid}/trash", HandleAsync);
	}

	private static async Task<IResult> HandleAsync([FromRoute] Guid nodeId, ISender sender)
	{
		var command = new DeleteNodeCommand(nodeId);

		var result = await sender.Send(command);

		return result.Match(_ => Results.NoContent(), errors => errors.ToProblem());
	}
}
