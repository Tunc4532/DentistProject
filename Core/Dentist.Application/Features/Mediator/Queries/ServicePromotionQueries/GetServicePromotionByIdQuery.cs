﻿using Dentist.Application.Features.Mediator.Results.ServicePromotionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.ServicePromotionQueries
{
    public class GetServicePromotionByIdQuery : IRequest<GetServicePromotionByIdQueryResult>
    {
        public int Id { get; set; }

        public GetServicePromotionByIdQuery(int id)
        {
            Id = id;
        }
    }
}