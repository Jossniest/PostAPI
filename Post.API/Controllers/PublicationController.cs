using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Post.API.Responses;
using Post.Core.DTOs;
using Post.Core.Entities;
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

    public class PublicationController : ControllerBase
    {
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;

        public PublicationController(IPublicationService PostRepo, IMapper mapper)
        {
            _publicationService = PostRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var publications = await _publicationService.GetPublications();
            var publicationsDTO = _mapper.Map<IEnumerable<PublicationDTO>>(publications);
            var response = new ApiResponse<IEnumerable<PublicationDTO>>(publicationsDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var publication = await _publicationService.GetPublication(id);
            var publicationDTO = _mapper.Map<PublicationDTO>(publication);
            var response = new ApiResponse<PublicationDTO>(publicationDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PublicationDTO publication)
        {
            var publicationPost = _mapper.Map<Publication>(publication);
            await _publicationService.InsertPublication(publicationPost);
            publication = _mapper.Map<PublicationDTO>(publicationPost);
            var response = new ApiResponse<PublicationDTO>(publication);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PublicationDTO publication)
        {
            var publicationPost = _mapper.Map<Publication>(publication);
            publicationPost.Id = id;
            var result = await _publicationService.PutPublication(publicationPost);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _publicationService.DeletePublication(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
