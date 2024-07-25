using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.PatientCommands
{
	public class RemovePatientCommand : IRequest
	{
        public int Id { get; set; }

		public RemovePatientCommand(int id)
		{
			Id = id;
		}
	}
}
