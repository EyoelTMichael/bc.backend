using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.RFIFeature.Query;

public class GetRFIChatByFileDetailQuery : IRequest<RFIChat>
{
    public Guid FileDetailId { get; set; }
}


