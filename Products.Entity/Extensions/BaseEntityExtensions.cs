using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Entity.Extensions
{
    public static class BaseEntityExtensions
    {
        [Obsolete("GenerateId is deprecated. Use database default instead.")]
        public static void GenerateId(this BaseEntity entity)
        {
            entity.Id = Guid.NewGuid();
        }
    }
}
