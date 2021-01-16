using API.Models.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validation.Users
{
    public class UserValidator : AbstractValidator<User>
    {

        public UserValidator()
        {

        }

    }
}
