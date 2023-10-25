using Appointment.Application.Dtos;

namespace Appointment.Application.Services
{
    public interface IAppointmentService
    {
        IQueryable<AppointmentDto> GetAll();
        Task<AppointmentDto?> GetByIdAsync(int id);
        Task<int> AddAppointment(AddAppointmentDto model);
    }
}
