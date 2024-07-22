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
    public class GetCoverLetterByIdQueryHandler : IRequestHandler<GetCoverLetterByIdQuery, GetCoverLetterByIdQueryResult>
    {
        private readonly IRepository<CoverLetter> _repository;

        public GetCoverLetterByIdQueryHandler(IRepository<CoverLetter> repository)
        {
            _repository = repository;
        }

        public async Task<GetCoverLetterByIdQueryResult> Handle(GetCoverLetterByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetCoverLetterByIdQueryResult
            {
                CoverLetterId = values.CoverLetterId,
                Title = values.Title,
                Image = values.Image,
                Description = values.Description,
            };
        }
    }
}
