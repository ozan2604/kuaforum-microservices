using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Repositories.AppointmentRepositories;
using Appointment.Application.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Application.Features.Appointments.Queries.GetAppointments;

public class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentsQueryRequest, Result<List<ResultAppointmentDto>>>
{
    private readonly IAppointmentRepository _repository;
    private readonly IMapper _mapper;

    public GetAppointmentsQueryHandler(IAppointmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultAppointmentDto>>> Handle(GetAppointmentsQueryRequest request, CancellationToken cancellationToken)
    {
        var appointments = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultAppointmentDto>>(appointments);
        return Result<List<ResultAppointmentDto>>.SuccessResult(dtoList);
    }
}
