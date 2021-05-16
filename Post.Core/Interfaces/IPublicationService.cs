using Post.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Post.Core.Interfaces
{
    public interface IPublicationService
    {
        Task<IEnumerable<Publication>> GetPublications();
        Task<Publication> GetPublication(int id);
        Task InsertPublication(Publication publication);
        Task<bool> PutPublication(Publication publication);
        Task<bool> DeletePublication(int id);
    }
}
