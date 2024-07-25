using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.AppointmentCommands
{
	public class RemoveAppointmentCommand : IRequest
	{
        public int Id { get; set; }

		public RemoveAppointmentCommand(int id)
		{
			Id = id;
		}
	}
}
