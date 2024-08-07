﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.DoctorCommands
{
	public class CreateDoctorCommand : IRequest
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Image { get; set; }
		public DateTime BirthDate { get; set; }
		public string Address { get; set; }
		public bool IsApproved { get; set; }

		public int? UserId { get; set; }
	}
}
