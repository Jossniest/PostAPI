using Post.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Post.Core.Interfaces
{
    public interface IPostRepo
    {
        Task<IEnumerable<Publication>> GetPublications();
        Task<Publication> GetPublication(int id);
    }
}
