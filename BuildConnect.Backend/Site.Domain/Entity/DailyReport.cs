using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class DailyReport : BaseModel
    {
        public DateTime Date { get; set; }
        public int WorkHour { get; set; }
        public int InterruptedHour { get; set; }
        public string Weather { get; set; }
    }
    public class DailyReportDto
    {
        public int WorkHour { get; set; }
        public int InterruptedHour { get; set; }
        public string Weather { get; set; }
        public IEnumerable<StaffOnSiteDto> StaffsOnSite { get; set; }
        public IEnumerable<LabourForceDto> LabourForces { get; set; }
        public IEnumerable<MaterialReportDto> MaterialsReport { get; set; }
    }
}
