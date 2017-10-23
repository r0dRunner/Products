using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.API.DTOs
{
    public class ProductOptionDTO : BaseDTO
    {
        public override Guid Id { get; set; }

        public override string Name { get; set; }

        public override string Description { get; set; }

    }
}