﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Library.Models
{
    public class ProductAddModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, Price: {Price}, Quantity: {Quantity}";
        }
    }
}
