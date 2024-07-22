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
    public class UpdateCategoryCardCommandHandler : IRequestHandler<UpdateCategoryCardCommand>
    {
        private readonly IRepository<CategoryCard> _repository;

        public UpdateCategoryCardCommandHandler(IRepository<CategoryCard> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCardCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.CategoryCardId);
            values.Description = request.Description;
            values.Icon = request.Icon;
            values.Title = request.Title;
            
            await _repository.UpdateAsync(values);
        }
    }
}
