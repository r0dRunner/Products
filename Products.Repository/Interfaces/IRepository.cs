using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> RetrieveAsync();

        Task<T> RetrieveByIdAsync(Guid id);

        Task<T> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(Guid id);
    }
}
