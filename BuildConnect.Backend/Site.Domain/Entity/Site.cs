using Site.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Domain.Entity
{
    public class SiteModel: BaseModel
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public long Longitude { get; set; }
        public long Latitude { get; set; }
    }

    public class SiteDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public long Longitude { get; set; }
        public long Latitude { get; set; }
    }
}
