using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.FileFeature.Query;

public class GetFileByFolderIdQueryHandler : IRequestHandler<GetFileByFolderIdQuery, IEnumerable<FileModelDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileService _fileService;

    public GetFileByFolderIdQueryHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;

        _fileService = fileService;
    }

    public async Task<IEnumerable<FileModelDto>> Handle(GetFileByFolderIdQuery request, CancellationToken cancellationToken)
    {
        var files = await _context.FileModels
                                  .Where(f => f.FolderId == request.FolderId)
                                  .ToListAsync(cancellationToken);

        var fileIds = files.Select(f => f.Id).ToList();

        var fileDetails = await _context.FileDetails
                                        .Where(fd => fileIds.Contains(fd.FileId))
                                        .ToListAsync(cancellationToken);

        var fileModelDtos = new List<FileModelDto>();

        foreach (var file in files)
        {
            var fileModelDto = new FileModelDto
            {
                Id = file.Id,
                File = await _fileService.ConvertFileToBase64(file.File, "Content"),
                FileName = file.FileName,
                FileDetails = fileDetails.Where(fd => fd.FileId == file.Id)
                                         .Select(fd => new FileDetailDto
                                         {
                                             Details = fd.Details,
                                             FileType = fd.FileType,
                                             x = fd.x,
                                             y = fd.y
                                         }).ToList()
            };

            fileModelDtos.Add(fileModelDto);
        }

        return fileModelDtos;

    }
}
