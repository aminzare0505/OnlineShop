﻿using OnlineShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public string Des { get; set; }
    }
}
