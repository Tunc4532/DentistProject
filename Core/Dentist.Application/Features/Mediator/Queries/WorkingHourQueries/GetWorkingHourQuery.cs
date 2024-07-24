﻿using Dentist.Application.Features.Mediator.Results.WorkingHourResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.WorkingHourQueries
{
    public class GetWorkingHourQuery : IRequest<List<GetWorkingHourQueryResult>>
    {
    }
}
