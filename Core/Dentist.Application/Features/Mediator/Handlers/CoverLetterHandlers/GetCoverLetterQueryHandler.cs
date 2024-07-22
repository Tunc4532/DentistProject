using Dentist.Application.Features.Mediator.Queries.CoverLetterQueries;
using Dentist.Application.Features.Mediator.Results.CommentResults;
using Dentist.Application.Features.Mediator.Results.CoverLetterResults;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.CoverLetterHandlers
{
    public class GetCoverLetterQueryHandler : IRequestHandler<GetCoverLetterQuery, List<GetCoverLetterQueryResult>>
    {
        private readonly IRepository<CoverLetter> _repository;

        public GetCoverLetterQueryHandler(IRepository<CoverLetter> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCoverLetterQueryResult>> Handle(GetCoverLetterQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCoverLetterQueryResult
            {
                CoverLetterId = x.CoverLetterId,
                Description = x.Description,
                Image = x.Image,
                Title = x.Title

            }).ToList();
        }
    }
}
