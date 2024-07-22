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
    public class GetCategoryCardQueryHandler : IRequestHandler<GetCategoryCardQuery, List<GetCategoryCardQueryResult>>
    {
        private readonly IRepository<CategoryCard> _repository;

        public GetCategoryCardQueryHandler(IRepository<CategoryCard> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoryCardQueryResult>> Handle(GetCategoryCardQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCategoryCardQueryResult
            {
                CategoryCardId = x.CategoryCardId,
                Description = x.Description,
                Icon = x.Icon,
                Title = x.Title,
            }).ToList();
        }
    }
}
