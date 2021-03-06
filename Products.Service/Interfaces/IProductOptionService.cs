﻿using Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Interfaces
{
    public interface IProductOptionService
    {
        Task<IEnumerable<ProductOptionModel>> RetrieveByProductIdAsync(Guid productId);

        Task<ProductOptionModel> RetrieveByProductIdAndIdAsync(Guid productId, Guid id);
        
        Task<ProductOptionModel> CreateAsync(Guid productId, ProductOptionModel productOption);

        Task UpdateAsync(Guid productId, Guid id, ProductOptionModel productOption);

        Task DeleteAsync(Guid productId, Guid id);
    }
}
