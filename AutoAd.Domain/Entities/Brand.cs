using AutoAd.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
