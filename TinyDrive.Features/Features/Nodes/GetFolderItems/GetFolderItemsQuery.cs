using ErrorOr;
using MediatR;
using TinyDrive.Features.Common.Models;

namespace TinyDrive.Features.Features.Nodes.GetFolderItems;

public sealed record GetFolderItemsQuery(Guid? ParentId, int PageNumber, int PageSize)
	: IRequest<ErrorOr<PaginatedList<FolderItem>>>;
