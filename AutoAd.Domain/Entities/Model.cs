using AutoAd.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Domain.Entities
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
