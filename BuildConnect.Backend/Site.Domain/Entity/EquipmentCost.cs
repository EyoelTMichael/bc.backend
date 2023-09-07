using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity
{
    public class EquipmentCost : BaseModel
    {
        public Guid Equipment { get; set; }
        public int Count { get; set; }
        public int UnitFactor { get; set; }
        public int HourlyRental { get; set; }
        [ForeignKey("WorkItem")]
        public Guid WorkItem { get; set; }
    }

    public class EquipmentCostDTO
    {
        public Guid Id { get; set; }
        public Guid Equipment { get; set; }
        public int Count { get; set; }
        public int UnitFactor { get; set; }
        public int HourlyRental { get; set; }
        public Guid WorkItem { get; set; }
    }
}
