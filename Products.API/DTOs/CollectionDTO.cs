using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.API.DTOs
{
    public class CollectionDTO<T>
    {
        public IEnumerable<T> Items { get; set; }

    }
}