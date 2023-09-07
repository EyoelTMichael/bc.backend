﻿using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity
{
    public class DailyReport : BaseModel
    {
        public DateTime Date { get; set; }
        public int WorkHour { get; set; }
        public int InterruptedHour { get; set; }
        public string? Weather { get; set; }
        [ForeignKey("Site")]
        public Guid SiteId { get; set; }

        [ForeignKey("User")]
        public Guid CreatedBy { get; set; }
        [ForeignKey("User")]
        public Guid? ApprovedBy { get; set; }
        public int? Profitable { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual User? ApprovedByUser { get; set; }
    }
    public class DailyReportDTO
    {
        public DateTime Date { get; set; }
        public int WorkHour { get; set; }
        public int InterruptedHour { get; set; }
        public string Weather { get; set; }
        public IEnumerable<StaffOnSiteDTO> StaffsOnSite { get; set; }
        public IEnumerable<LabourForceDTO> LabourForces { get; set; }
        public IEnumerable<MaterialReportDTO> MaterialsReport { get; set; }
        public IEnumerable<EquipmentReportDTO> EquipmentReport { get; set; }
        public UserDTO CreatedByUser { get; set; }
        public UserDTO? ApprovedByUser { get; set; }
        public int Profitable { get; set; }
    }
}
