using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailsDto : IDto
    {
        public int Id { get; set; }
        public String CarModel { get; set; }
        public String ColorName { get; set; }
        public String BrandName { get; set; }
    }
}
