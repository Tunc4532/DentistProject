﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Results.AppointmentResults
{
	public class GetAppointmentQueryResult
	{
		public int AppointmentId { get; set; }
		public string PatientTcKimlik { get; set; }
		public DateTime AppointmentDateTime { get; set; }
		public bool IsAvailable { get; set; }

		public int DoctorId { get; set; }
		public int? PatientId { get; set; }
	}
}
