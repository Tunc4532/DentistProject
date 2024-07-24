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
    public class GetWorkingHourByIdQueryHandler : IRequestHandler<GetWorkingHourByIdQuery, GetWorkingHourByIdQueryResult>
    {
        private readonly IRepository<WorkingHour> _repository;

        public GetWorkingHourByIdQueryHandler(IRepository<WorkingHour> repository)
        {
            _repository = repository;
        }

        public async Task<GetWorkingHourByIdQueryResult> Handle(GetWorkingHourByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetWorkingHourByIdQueryResult
            {
               DoctorId = values.DoctorId,
               WorkingHourId = values.WorkingHourId,
               Hour = values.Hour,
               Day = values.Day,
               Phone = values.Phone
            };
        }
    }
}
