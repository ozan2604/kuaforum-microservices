using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Repositories.AppointmentRepositories;
using Appointment.Application.Results;
using Appointment.Application.Services.CurrentUserServices;
using AutoMapper;
using MediatR;

namespace Appointment.Application.Features.Appointments.Commands.UpdateAppointment;

public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommandRequest, Result<Guid>>
{
    private readonly IAppointmentRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current;

    public UpdateAppointmentCommandHandler(IAppointmentRepository repository, IMapper mapper, ICurrentUserService current)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
    }

    public async Task<Result<Guid>> Handle(UpdateAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Appointment.Id);
        if (entity == null)
            return Result<Guid>.FailureResult("Kayıt bulunamadı.");

        _mapper.Map(request.Appointment, entity);
        entity.UpdateAt = DateTime.UtcNow;
        entity.UpdateUserId = _current.UserId;
        entity.UpdateUserName = _current.UserName ?? string.Empty;

        var updated = _repository.Update(entity);
        if (!updated)
            return Result<Guid>.FailureResult("Güncelleme başarısız.");

        var saved = await _repository.SaveAsync(cancellationToken);
        return saved > 0
            ? Result<Guid>.SuccessResult(entity.Id, "Başarıyla güncellendi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}
