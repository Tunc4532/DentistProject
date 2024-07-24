﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.SliderCommands
{
    public class CreateSliderCommand : IRequest
    {
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
    }
}