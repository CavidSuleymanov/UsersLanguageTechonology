using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.UpdateOperationclaim
{
    public class UpdateOperationClaimCommanValidator : AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimCommanValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
