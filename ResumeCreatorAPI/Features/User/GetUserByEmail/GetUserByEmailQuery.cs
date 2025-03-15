using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ResumeCreatorAPI.Features.User.GetUserByEmail
{
    public record GetUserByEmailQuery(string Email) : IRequest<GetUserByEmailResponse>;
}