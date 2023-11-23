using Appointment.Application.Dtos;
using Appointment.Infrastructure.Repositories;
using Appointment.Infrastructure.UnitOfWork;
using AutoMapper;

namespace Appointment.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppoimentRepository _appoimentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(
            IAppoimentRepository appoimentRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _appoimentRepository = appoimentRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddAppointment(AddAppointmentDto model)
        {
            var entity = _mapper.Map<Data.Entities.Appointment>(model);
            var data = await _appoimentRepository.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            return data.Id;
        }

        public IQueryable<AppointmentDto> GetAll()
        {
            return _appoimentRepository.GetAll().Select(x => _mapper.Map<AppointmentDto>(x));
        }

        public async Task<AppointmentDto?> GetByIdAsync(int id)
        {
            var data = await _appoimentRepository.GetByIdAsync(id);
            if (data is null)
            {
                return null;
            }

            return _mapper.Map<AppointmentDto>(data);
        }

        public async Task TestConcurrency()
        {
            await _appoimentRepository.TestConcurrency();
        }
    }
}
