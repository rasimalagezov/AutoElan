using AutoAd.Web.Service;

namespace AutoAd.Web.Models
{
    public class ModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public BrandDto? Brand { get; set; }
    }
}
