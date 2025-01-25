using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShark.Contracts.Base
{
    public interface BaseRepository<in T> where T : class
    {
        Task AddAsync(T entity);
        Task SaveChangesAsync();
    }
}
