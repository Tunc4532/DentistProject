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
    public class RegisterQueryHandler : IRequestHandler<RegisterQuery, RegisterQueryResult>
    {
        private readonly IRepository<User> _repository;
        private readonly int _iteration = 6;
        private readonly string _pepper = "XslMeQuwL2cqoksVkISEAlb26suddECzwGvBYUf4JmdkCmYl";

        public RegisterQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<RegisterQueryResult> Handle(RegisterQuery request, CancellationToken cancellationToken)
        {
            var username = await _repository.GetByFilterListAsync(x => x.UserName == request.Username || x.Email == request.Email);
            if (username.Count == 0)
            {

                var newpasswordsalt = PasswordHasher.GenerateSalt();
                var passwordHash = PasswordHasher.ComputeHash(request.Password, newpasswordsalt, _pepper, _iteration);

                await _repository.CreateAsync(new User
                {
                    UserName = request.Username,
                    PasswordSalt = newpasswordsalt,
                    PasswordHash = passwordHash,
                    BirthDate = request.BirthDate,
                    CreatedDate = request.CreatedDate,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Phone = request.Phone,
                    UserRoleId = request.UserRoleId,



                });
                return new RegisterQueryResult
                {
                    Message = "Kullanıcı başarıyla oluşturuldu"
                };
            }
            else
                return new RegisterQueryResult
                {
                    Message = "Böyle bir kullanıcı mevcut"
                };

        }
    }
}

