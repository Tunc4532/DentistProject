using Dentist.Application.Features.Mediator.Queries.AuthorizationQueries;
using Dentist.Application.Features.Mediator.Results.AuthorizationResults;
using Dentist.Application.Interfaces;
using Dentist.Application.Tools;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.AuthorizationHandlers
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResult>
    {
        private readonly IRepository<User> _appUserRepository;
        private readonly int _iteration = 6;
        private readonly string _pepper = "XslMeQuwL2cqoksVkISEAlb26suddECzwGvBYUf4JmdkCmYl";

        public LoginQueryHandler(IRepository<User> appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<LoginQueryResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var username = await _appUserRepository.GetByFilterAsync(x => x.UserName == request.UserName);
            var values = new LoginQueryResult();
            if (username != null)
            {

                var passwordHash = PasswordHasher.ComputeHash(request.Password, username.PasswordSalt, _pepper, _iteration);


                var user = await _appUserRepository.IncludeSingle(y => y.Role, x => x.UserName == request.UserName && x.PasswordHash == passwordHash);
                //var user2 = await _appUserRepository.IncludeSingle(x => x.Patients, x => x.UserName == request.UserName);
                //if (user2 != null && user2.UserRoleId == 3)
                //{
                //    values.PatientId = user2.Patients.FirstOrDefault().PatientId;
                //}
                if (user == null)
                    values.IsExist = false;
                else
                {
                    values.IsExist = true;
                    values.UserName = user.UserName;
                    values.Role = user.Role.RoleName;
                    //values.DoctorId = user?.DoctorId;
                    //values.PatientId = user?.DoctorId;
                    values.Id = user.UserId;
                }
            }
            else
                values.IsExist = false;
            return values;
        }
    }
}
