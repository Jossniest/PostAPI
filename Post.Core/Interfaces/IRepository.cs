using Post.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Post.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}
