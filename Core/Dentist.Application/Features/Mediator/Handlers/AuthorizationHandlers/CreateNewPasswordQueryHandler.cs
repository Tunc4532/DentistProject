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
    public class CreateNewPasswordQueryHandler : IRequestHandler<CreateNewPasswordQuery, CreateNewPasswordQueryResult>
	{
		private readonly IRepository<User> _repository;
		private readonly int _iteration = 6;
		private readonly string _pepper = "XslMeQuwL2cqoksVkISEAlb26suddECzwGvBYUf4JmdkCmYl";

		public CreateNewPasswordQueryHandler(IRepository<User> repository)
		{
			_repository = repository;
		}

		public async Task<CreateNewPasswordQueryResult> Handle(CreateNewPasswordQuery request, CancellationToken cancellationToken)
		{
			var message = "";
			var newpassword = "";
			var user = await _repository.GetByFilterAsync(x => x.UserName == request.Username);
			if (user != null)
			{
				message = "Success";
				var newpasswordsalt = PasswordHasher.GenerateSalt();
				newpassword = PasswordGenerator.GeneratePassword();
				var passwordHash = PasswordHasher.ComputeHash(newpassword, newpasswordsalt, _pepper, _iteration);

				user.PasswordSalt = newpasswordsalt;
				user.PasswordHash = passwordHash;
				await _repository.UpdateAsync(user);

			}
			else
				message = "Böyle bir kullanıcı bulunamadı.";
			return new CreateNewPasswordQueryResult
			{
				NewPassword = newpassword,
				Message = message
			};
		}
	}
}
