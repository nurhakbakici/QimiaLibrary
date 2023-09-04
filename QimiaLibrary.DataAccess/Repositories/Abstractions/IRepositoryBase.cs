using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.DataAccess.Repositories.Abstractions;

public interface IRepositoryBase<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T> GetByIdAsync(int id, CancellationToken cancellation = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    Task DeleteAsync(T Entity, CancellationToken cancellationToken);
    Task CreateAsync(T Entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T Entity, CancellationToken cancellationToken);
}