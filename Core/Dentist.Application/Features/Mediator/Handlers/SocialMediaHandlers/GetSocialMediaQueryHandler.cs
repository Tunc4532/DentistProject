using Dentist.Application.Features.Mediator.Queries.SocialMediaQueries;
using Dentist.Application.Features.Mediator.Results.SliderResults;
using Dentist.Application.Features.Mediator.Results.SocialMediaResults;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSocialMediaQueryResult
            {
                Icon = x.Icon,
                Url = x.Url,
                DoctorId = x.DoctorId,
                SocialMediaId = x.SocialMediaId,
                
            }).ToList();
        }
    }
}
