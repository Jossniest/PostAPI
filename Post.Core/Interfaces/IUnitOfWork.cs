using Post.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Post.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Publication> PublicationRepo { get; }
        public IRepository<User> UserRepo { get; }
        public IRepository<Comment> CommentRepo { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
