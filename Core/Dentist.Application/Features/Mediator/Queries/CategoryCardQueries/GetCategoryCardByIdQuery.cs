﻿using Dentist.Application.Features.Mediator.Results.CategoryCardResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.CategoryCardQueries
{
    public class GetCategoryCardByIdQuery : IRequest<GetCategoryCardByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCategoryCardByIdQuery(int id)
        {
            Id = id;
        }
    }
}
