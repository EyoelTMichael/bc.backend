using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.FoldersFeature.Command;

public class CreateFolderCommand: IRequest<FolderDto>
{
    public string Name { get; set; }
}
