using FluentValidation;
using Post.Core.DTOs;

namespace Post.Infrastructure.Validators
{
    public class PublicationValidator : AbstractValidator<PublicationDTO>
    {
        public PublicationValidator()
        {
            RuleFor(publicationDTO => publicationDTO.Description)
                .NotNull()
                .MaximumLength(500)
                .WithName("Descripcion");

            RuleFor(publicationDTO => publicationDTO.Date)
               .NotNull()
               .WithName("Fecha"); 

            RuleFor(publicationDTO => publicationDTO.UserId)
                .NotNull()
                .GreaterThan(0)
                .WithName("Id de usuario");
        }
    }
}
