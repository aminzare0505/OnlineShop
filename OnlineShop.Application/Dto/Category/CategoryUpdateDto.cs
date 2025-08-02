using OnlineShop.Application.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dto.Category
{
    public class CategoryUpdateDto:BaseDto
    {
        public string Name { get; set; }
        public string Des { get; set; }
    }
}
