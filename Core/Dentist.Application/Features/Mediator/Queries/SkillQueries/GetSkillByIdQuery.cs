﻿using Dentist.Application.Features.Mediator.Results.SkillResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.SkillQueries
{
    public class GetSkillByIdQuery : IRequest<GetSkillByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSkillByIdQuery(int id)
        {
            Id = id;
        }
    }
}
