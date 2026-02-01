using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TinyDrive.Features.Common.Constants;
using TinyDrive.Features.Common.Extensions;

namespace TinyDrive.Features.Features.Nodes.CreateFolder;

public sealed class CreateFolderEndpoint : ICarterModule
{

	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("api/nodes", HandleAsync)
			.WithTags(Tags.Nodes);
	}

	private static async Task<IResult> HandleAsync([FromBody] CreateFolderRequest request, ISender sender)
	{
		var command = new CreateFolderCommand(request.Name, request.ParentFolderId);

		var result = await sender.Send(command);

		return result.Match(Results.Ok, errors => errors.ToProblem());
	}
}
