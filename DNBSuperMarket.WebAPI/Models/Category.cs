﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DNBSuperMarket.WebAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
