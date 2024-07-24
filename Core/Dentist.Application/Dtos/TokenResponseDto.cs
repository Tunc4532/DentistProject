using Dentist.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Dtos
{
    public class TokenResponseDto
    {
        public TokenResponseDto()
        {

        }
        public TokenResponseDto(string token, DateTime expireDate, string userId, string userName)
        {
            Token = token;
            ExpireDate = expireDate;
            UserId = userId;
            UserName = userName;
            //DoctorId = doctorId;
            //PatientId = patientId;
        }

        public TokenResponseDto(string token, DateTime expireDate, string userId, string userName, string message)
        {
            Token = token;
            UserName = userName;
            UserId = userId;
            ExpireDate = expireDate;
            Message = message;
            //DoctorId = doctorId;
        }

        public string Token { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Message { get; set; }
        //public int? DoctorId { get; set; }
        //public int? PatientId{ get; set; }
    }
}

