using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Queries.Gearboxes.GetGearboxById
{
    public class GetGearboxByIdQueryResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
