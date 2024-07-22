using Dentist.Application.Features.Mediator.Queries.CategoryCardQueries;
using Dentist.Application.Features.Mediator.Results.CategoryCardResults;
using Dentist.Application.Features.Mediator.Results.CommentResults;
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
    public class GetCategoryCardByIdQueryHandler : IRequestHandler<GetCategoryCardByIdQuery, GetCategoryCardByIdQueryResult>
    {
        private readonly IRepository<CategoryCard> _repository;

        public GetCategoryCardByIdQueryHandler(IRepository<CategoryCard> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryCardByIdQueryResult> Handle(GetCategoryCardByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetCategoryCardByIdQueryResult
            {
                CategoryCardId = values.CategoryCardId,
                Description = values.Description,
                Icon = values.Icon,
                Title = values.Title,
            };
        }
    }
}
