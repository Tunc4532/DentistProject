using Dentist.Application.Features.Mediator.Queries.WorkingHourQueries;
using Dentist.Application.Features.Mediator.Results.SupportResults;
using Dentist.Application.Features.Mediator.Results.WorkingHourResults;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.WorkingHourHandlers
{
    public class GetWorkingHourQueryHandler : IRequestHandler<GetWorkingHourQuery, List<GetWorkingHourQueryResult>>
    {
        private readonly IRepository<WorkingHour> _repository;

        public GetWorkingHourQueryHandler(IRepository<WorkingHour> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetWorkingHourQueryResult>> Handle(GetWorkingHourQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetWorkingHourQueryResult
            {
               WorkingHourId = x.WorkingHourId,
               Day = x.Day,
               Hour = x.Hour,
               Phone = x.Phone,
               DoctorId = x.DoctorId

            }).ToList();
        }
    }
}
