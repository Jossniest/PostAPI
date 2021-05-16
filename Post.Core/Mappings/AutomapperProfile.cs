using AutoMapper;
using Post.Core.DTOs;
using Post.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Core.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Publication, PublicationDTO>();
            CreateMap<PublicationDTO, Publication>();
        }
    }
}
