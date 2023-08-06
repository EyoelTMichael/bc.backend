using Site.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Domain.Entity
{
    public class Lookup: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
