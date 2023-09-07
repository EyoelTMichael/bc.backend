using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.FileFeature.Query;


public class GetFileByFolderIdQuery : IRequest<IEnumerable<FileModelDto>>
{
    public Guid FolderId { get; set; }
}
public class GetFileQuery : IRequest<FileModelDto>
{
    public Guid Id { get; set; }
}

