﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groce.Models
{
    public class GroceryType
    {
        public Groceries grocery { get; set; }

        public IEnumerable<Pricing> pricings { get; set; }

    }
}
