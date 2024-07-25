using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.DoctorCommands
{
	public class RemoveDoctorCommand : IRequest
	{
        public int Id { get; set; }

		public RemoveDoctorCommand(int id)
		{
			Id = id;
		}
	}
}
