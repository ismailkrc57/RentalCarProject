using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailsDto : IDto
    {
        public decimal DailyPrice { get; set; }
        public String CarModel { get; set; }
        public String ColorName { get; set; }
        public String BrandName { get; set; }
    }
}
