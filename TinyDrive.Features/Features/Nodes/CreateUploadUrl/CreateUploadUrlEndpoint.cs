using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TinyDrive.Features.Common.Extensions;

namespace TinyDrive.Features.Features.Nodes.CreateUploadUrl;

public sealed class CreateUploadUrlEndpoint : ICarterModule
{

	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("api/nodes/upload-url", HandleAsync);
	}

	private static async Task<IResult> HandleAsync([FromBody] CreateUploadUrlRequest request, ISender sender)
	{
		var command = new CreateUploadUrlCommand(request.FileName, request.FileSizeBytes, request.ContentType,
			request.ParentFolderId);

		var result = await sender.Send(command);

		return result.Match(Results.Ok, errors => errors.ToProblem());
	}
}
