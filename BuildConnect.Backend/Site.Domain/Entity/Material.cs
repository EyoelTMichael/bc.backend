using Site.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Domain.Entity
{
    public class Material : BaseModel
    {
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
    }
    public class MaterialDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
    }
}
