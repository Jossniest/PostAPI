using Post.Core.Entities;
using Post.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Infrastructure.Repositories
{
    public class PostRepo : IPostRepo
    {
        public async Task<IEnumerable<Posts>> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x =>
                new Posts
                {
                    PostId = x,
                    Description = $"Descripción {x}",
                    Date = DateTime.Now,
                    Image = $"https://example.com/{x}.jpg",
                    UserId = x * 2
                }
            );
            await Task.Delay(100);
            return posts;
        }

    }
}
