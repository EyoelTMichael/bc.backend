using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class Material : BaseModel
    {
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public Guid SiteId { get; set; }
    }
    public class MaterialDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public Guid SiteId { get; set; }
    }
}
