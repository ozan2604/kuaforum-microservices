using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Repositories.AppointmentRepositories;
using Appointment.Application.Results;
using Appointment.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Appointment.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommandRequest, Result<Guid>>
{
    private readonly IAppointmentRepository _repository;
    private readonly IMapper _mapper;

    public CreateAppointmentCommandHandler(IAppointmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Appointment.Domain.Entities.Appointment>(request.Appointment);
        var added = await _repository.AddAsync(entity, cancellationToken);
        if (!added)
            return Result<Guid>.FailureResult("Ekleme başarısız.");

        var saved = await _repository.SaveAsync(cancellationToken);
        return saved > 0
            ? Result<Guid>.SuccessResult(entity.Id, "Başarıyla eklendi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}
