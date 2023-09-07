using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity
{
    public class Inspection : BaseModel
    {
        public string Description { get; set; }
        public InspectionStatus? Status { get; set; }
        [ForeignKey("Schedule")]
        public Guid ScheduleId { get; set; }
        //[ForeignKey("Site")]
        //public Guid SiteId { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
    public enum InspectionStatus
    {
        Pass,
        Fail,
        NA,
    }

    public class InspectionDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public InspectionStatus? Status { get; set; }
        [ForeignKey("Schedule")]
        public Guid ScheduleId { get; set; }
        //[ForeignKey("Site")]
        //public Guid SiteId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
