using Appointment.Application.Dtos;
using AutoMapper;

namespace Appointment.Application.AutoMappers
{
    internal class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Data.Entities.Appointment, AppointmentDto>().ReverseMap();
            CreateMap<AddAppointmentDto, Data.Entities.Appointment>();
        }
    }
}
