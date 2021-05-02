using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Post.Core.Interfaces;
using Post.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepo _postRepo;

        public PostController(IPostRepo PostRepo)
        {
            _postRepo = PostRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var publications = await _postRepo.GetPublications();
            return Ok(publications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var publication = await _postRepo.GetPublication(id);
            return Ok(publication);
        }
    }
}
