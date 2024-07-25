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
	public class ResetPasswordQueryHandler : IRequestHandler<ResetPasswordQuery, ResetPasswordQueryResult>
	{
		private readonly IRepository<User> _repository;
		private readonly int _iteration = 6;
		private readonly string _pepper = "XslMeQuwL2cqoksVkISEAlb26suddECzwGvBYUf4JmdkCmYl";

		public ResetPasswordQueryHandler(IRepository<User> repository)
		{
			_repository = repository;
		}

		public async Task<ResetPasswordQueryResult> Handle(ResetPasswordQuery request, CancellationToken cancellationToken)
		{
			ResetPasswordQueryResult result = new();
			var user = await _repository.GetByFilterAsync(x => x.UserName == request.Username);
			if (user != null)
			{

				var passwordHash = PasswordHasher.ComputeHash(request.OldPassword, user.PasswordSalt, _pepper, _iteration);
				if (passwordHash == user.PasswordHash)
				{
					var newpasswordsalt = PasswordHasher.GenerateSalt();
					user.PasswordSalt = newpasswordsalt;
					user.PasswordHash = PasswordHasher.ComputeHash(request.NewPassword, newpasswordsalt, _pepper, _iteration);
					await _repository.UpdateAsync(user);
					result.Message = "Şifre başarıyla değiştirildi.";
				}
				else
					result.Message = "Eski şifre hatalı";

			}
			else
				result.Message = "Böyle bir kullanıcı bulunamadı";

			return result;
		}
	}
}
