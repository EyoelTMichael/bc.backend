using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;
using System.Text.RegularExpressions;

namespace Site.Application.Features.FileFeature.Command;

public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileService _fileService;

    public CreateFileCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }
    public string GetFileTypeFromBase64(string base64DataUrl)
    {
        var match = Regex.Match(base64DataUrl, @"^data:image\/([a-zA-Z0-9]+);base64,");
        if (match.Success && match.Groups.Count > 1)
        {
            return match.Groups[1].Value;
        }
        return null;
    }
    public async Task<Guid> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        string fileName = null;
        if (!string.IsNullOrEmpty(request.File))
        {
            byte[] imageBytes = Convert.FromBase64String(request.File.Split(',')[1]);
            string fileType = GetFileTypeFromBase64(request.File);
            fileName = await _fileService.SaveFileAsync(imageBytes, fileType, "File");
        }
        var newFile = new FileModel
        {
            FolderId = request.FolderId,
            FileName = request.FileName,
            File = fileName
        };

        _context.FileModels.Add(newFile);
        await _context.SaveChangesAsync(cancellationToken);

        return newFile.Id;
    }
}
