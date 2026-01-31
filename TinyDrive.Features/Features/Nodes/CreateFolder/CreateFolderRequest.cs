namespace TinyDrive.Features.Features.Nodes.CreateFolder;

public sealed record CreateFolderRequest(string Name, Guid? ParentFolderId);
