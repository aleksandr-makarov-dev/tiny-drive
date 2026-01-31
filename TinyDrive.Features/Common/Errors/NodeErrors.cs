using ErrorOr;

namespace TinyDrive.Features.Common.Errors;

public static class NodeErrors
{
	private const string Prefix = "Node";

	public static Error ParentFolderNotFound() =>
		Error.NotFound(
			$"{Prefix}.ParentFolderNotFound",
			"Parent folder not found.");

	public static Error FolderAlreadyExists() =>
		Error.Conflict(
			$"{Prefix}.FolderAlreadyExists",
			"Folder already exists.");

	public static Error NodeNotFound(Guid nodeId) =>
		Error.NotFound(
			$"{Prefix}.NotFound",
			$"Node with id '{nodeId}' was not found.");

	public static Error CreateUploadUrlFailure() => Error.Unexpected($"{Prefix}.CreateUploadUrl",
		"An unexpected error occured during creating the upload url");

	public static Error FileAlreadyExists() =>
		Error.Conflict(
			$"{Prefix}.FolderAlreadyExists",
			"File already exists.");
}
