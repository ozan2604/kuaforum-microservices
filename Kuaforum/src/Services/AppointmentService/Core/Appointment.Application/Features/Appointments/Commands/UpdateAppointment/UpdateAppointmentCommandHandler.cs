using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Repositories.AppointmentRepositories;
using Appointment.Application.Results;
using AutoMapper;
using MediatR;

namespace Appointment.Application.Features.Appointments.Commands.UpdateAppointment;

public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommandRequest, Result<Guid>>
{
    private readonly IAppointmentRepository _repository;
    private readonly IMapper _mapper;

    public UpdateAppointmentCommandHandler(IAppointmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(UpdateAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Appointment.Id);
        if (entity == null)
            return Result<Guid>.FailureResult("Kayıt bulunamadı.");

        _mapper.Map(request.Appointment, entity);
        var updated = _repository.Update(entity);
        if (!updated)
            return Result<Guid>.FailureResult("Güncelleme başarısız.");

        var saved = await _repository.SaveAsync(cancellationToken);
        return saved > 0
            ? Result<Guid>.SuccessResult(entity.Id, "Başarıyla güncellendi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}
