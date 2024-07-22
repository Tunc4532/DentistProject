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
    public class RemoveCategoryCardCommandHandler : IRequestHandler<RemoveCategoryCardCommand>
    {
        private readonly IRepository<CategoryCard> _repository;

        public RemoveCategoryCardCommandHandler(IRepository<CategoryCard> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCategoryCardCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
