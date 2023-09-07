using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class Folder : BaseModel
    {
        public string Name { get; set; }
        public Guid SiteId { get; set; }
    }

    public class FolderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SiteId { get; set; }
        public List<FileModelDto?> Files { get; set; }
    }
}
