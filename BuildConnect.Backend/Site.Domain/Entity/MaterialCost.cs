using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity
{
    public class MaterialCost : BaseModel
    {
        [ForeignKey(nameof(Material))]
        public Guid TypeOfMaterial { get; set; }
        public Guid Unit { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public int CostPerUnit { get; set; }
        [ForeignKey(nameof(WorkItem))]
        public Guid WorkItem { get; set; }
    }


    public class MaterialCostDTO
    {
        public Guid Id { get; set; }
        public MaterialDTO TypeOfMaterial { get; set; }
        public Guid Unit { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public int CostPerUnit { get; set; }
        public Guid WorkItem { get; set; }
    }
}
