using Products.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Repository.Interfaces
{
    public interface IProductOptionRepository: IRepository<ProductOptionEntity>
    {
        Task<IEnumerable<ProductOptionEntity>> RetrieveByProductIdAsync(Guid productId);
    }
}
