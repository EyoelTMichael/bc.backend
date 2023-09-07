using MediatR;


namespace Site.Application.Features.FileFeature.Command;

public class CreateFileCommand : IRequest<Guid>
{
    public Guid FolderId { get; set; }
    public string FileName { get; set; }
    public string File { get; set; }

}