using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Repositories.AppointmentRepositories;
using Appointment.Application.Results;
using AutoMapper;
using MediatR;

namespace Appointment.Application.Features.Appointments.Queries.GetAppointmentById;

public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQueryRequest, Result<ResultAppointmentDto>>
{
    private readonly IAppointmentRepository _repository;
    private readonly IMapper _mapper;

    public GetAppointmentByIdQueryHandler(IAppointmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultAppointmentDto>> Handle(GetAppointmentByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var appointment = await _repository.GetByIdAsync(request.Id);
        if (appointment == null)
            return Result<ResultAppointmentDto>.FailureResult("Kayıt bulunamadı.");
        var dto = _mapper.Map<ResultAppointmentDto>(appointment);
        return Result<ResultAppointmentDto>.SuccessResult(dto);
    }
}
