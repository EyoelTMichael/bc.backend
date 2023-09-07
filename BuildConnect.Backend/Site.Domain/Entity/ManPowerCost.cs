using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace Site.Domain.Entity
{
    public class ManPowerCost : BaseModel
    {
        public Guid Labour { get; set; }
        public int Count { get; set; }
        public int HourlyCost { get; set; }
        [ForeignKey("WorkItem")]
        public Guid WorkItem { get; set; }
    }

    public class ManPowerCostDTO
    {
        public Guid Id { get; set; }
        public Guid Labour { get; set; }
        public int Count { get; set; }
        public int HourlyCost { get; set; }
        public Guid WorkItem { get; set; }
    }
}
