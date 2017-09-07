﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTenta.Models
{
    public class Product
    {
        [Required]
        public string Name { get; set; }
        [Range(5, 1000)]
        public decimal Price { get; set; }
    }
}
