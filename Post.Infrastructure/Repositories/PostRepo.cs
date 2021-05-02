using Post.Core.Entities;
using Post.Core.Interfaces;
using Post.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Post.Infrastructure.Repositories
{
    public class PostRepo : IPostRepo
    {
        private readonly PostDbContext _context;

        public PostRepo(PostDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Publication>> GetPublications()
        {
            var posts = await _context.Publications.ToListAsync();
            return posts;
        }

        public async Task<Publication> GetPublication(int id)
        {
            var post = await _context.Publications.FirstOrDefaultAsync(x => x.PublicationId == id);
            return post;
        }
    }
}
