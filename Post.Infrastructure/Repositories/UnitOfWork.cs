using Post.Core.Entities;
using Post.Core.Interfaces;
using Post.Infrastructure.Data;
using System.Threading.Tasks;

namespace Post.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostDbContext _context;
        private readonly IRepository<Publication> _publicationRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Comment> _commentRepo;

        public UnitOfWork(PostDbContext context)
        {
            _context = context;
        }

        public IRepository<Publication> PublicationRepo => _publicationRepo ?? new BaseRepository<Publication>(_context);

        public IRepository<User> UserRepo => _userRepo ?? new BaseRepository<User>(_context);


        public IRepository<Comment> CommentRepo => _commentRepo ?? new BaseRepository<Comment>(_context);


        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
