using Appointment.Application.Dtos;
using FluentValidation;

namespace Appointment.API.Validators
{
    public class CreateAppointmentDtoValidator: AbstractValidator<AddAppointmentDto>
    {
        public CreateAppointmentDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
