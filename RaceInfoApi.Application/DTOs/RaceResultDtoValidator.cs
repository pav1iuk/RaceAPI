using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace RaceInfoApi.Application.DTOs
{
    public class RaceResultDtoValidator: AbstractValidator<RaceResultDto>
    {
        public RaceResultDtoValidator()
        {
            RuleFor(x => x.RaceId)
                .GreaterThan(0).WithMessage("RaceId must be greater than 0");

            RuleFor(x => x.DriverId)
                .GreaterThan(0).WithMessage("DriverId must be greater than 0");

            RuleFor(x => x.Position)
                .GreaterThan(0).WithMessage("Position must be a positive number");

            RuleFor(x => x.FinishTime)
                .NotEmpty()
                .WithMessage("Time is required.");
        }
    }
}
