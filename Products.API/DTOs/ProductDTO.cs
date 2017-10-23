using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products.API.DTOs
{
    public class ProductDTO : BaseDTO
    {
        public override Guid Id { get; set; }

        public override string Name { get; set; }

        public override string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        
    }
}