using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;


namespace Site.Application.Features.FileFeature.Query
{
    public class GetFileQueryHandler : IRequestHandler<GetFileQuery, FileModelDto>
    {
        private readonly IApplicationDbContext _context;

        public GetFileQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FileModelDto> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            var file = await _context.FileModels.FindAsync(request.Id);
            if (file == null)
            {
                throw new NotFoundException(nameof(FileModel), request.Id);
            }

            var fileDetails = await _context.FileDetails
                                         .Where(fd => fd.FileId == request.Id)
                                         .ToListAsync(cancellationToken);

            return new FileModelDto
            {
                Id = file.Id,
                File = file.File,
                FileName = file.FileName,
                FileDetails = fileDetails.Select(fd => new FileDetailDto
                {
                    Details = fd.Details,
                    FileType = fd.FileType,
                    X = fd.X,
                    Y = fd.Y
                }).ToList()
            };
        }
    }
}
