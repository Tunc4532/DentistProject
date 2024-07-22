using Dentist.Application.Features.Mediator.Commands.CategoryCardCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.CategoryCardHandlers
{
    public class CreateCategoryCardCommandHandler : IRequestHandler<CreateCategoryCardCommand>
    {
        private readonly IRepository<CategoryCard> _repository;

        public CreateCategoryCardCommandHandler(IRepository<CategoryCard> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCategoryCardCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CategoryCard
            {
                Description = request.Description,
                Icon = request.Icon,
                Title = request.Title,
            });
        }
    }
}
