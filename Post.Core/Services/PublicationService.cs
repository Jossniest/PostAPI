using Post.Core.Entities;
using Post.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Post.Core.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PublicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Publication>> GetPublications()
        {
            return await _unitOfWork.PublicationRepo.GetAll();
        }

        public async Task<Publication> GetPublication(int id)
        {
            return await _unitOfWork.PublicationRepo.GetById(id);
        }

        public async Task InsertPublication(Publication publication)
        {
            User user = await _unitOfWork.UserRepo.GetById(publication.UserId);
            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            await _unitOfWork.PublicationRepo.Insert(publication);
        }

        public async Task<bool> PutPublication(Publication publication)
        {
            return await _unitOfWork.PublicationRepo.Update(publication);
        }

        public async Task<bool> DeletePublication(int id)
        {
            return await _unitOfWork.PublicationRepo.Delete(id);
        }
    }
}
