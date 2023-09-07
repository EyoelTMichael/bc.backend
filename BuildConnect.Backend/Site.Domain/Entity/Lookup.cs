using Site.Domain.Common;

namespace Site.Domain.Entity;

public class Lookup: BaseModel
{
    public string Name { get; set; }
    public LookupType LookupType { get; set; }
    public Guid SiteId { get; set; }
    public string Description { get; set; }
}

public enum LookupType
{
    UnitOfMeasure,
    Material,
    Equipment
}

public class LookupDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public LookupType LookupType { get; set; }
    public Guid SiteId { get; set; }
    public string Description { get; set; }
}