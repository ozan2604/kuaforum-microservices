using Appointment.Application.Dtos.AppointmentHistoryDtos;
using Appointment.Application.Repositories.AppointmentHistoryRepositories;
using Appointment.Application.Results;
using AutoMapper;
using MediatR;

namespace Appointment.Application.Features.AppointmentHistories.Commands.UpdateAppointmentHistory;

public class UpdateAppointmentHistoryCommandHandler : IRequestHandler<UpdateAppointmentHistoryCommandRequest, Result<Guid>>
{
    private readonly IAppointmentHistoryRepository _repository;
    private readonly IMapper _mapper;

    public UpdateAppointmentHistoryCommandHandler(IAppointmentHistoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(UpdateAppointmentHistoryCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.History.Id);
        if (entity == null)
            return Result<Guid>.FailureResult("Kayıt bulunamadı.");

        _mapper.Map(request.History, entity);
        var updated = _repository.Update(entity);
        if (!updated)
            return Result<Guid>.FailureResult("Güncelleme başarısız.");

        var saved = await _repository.SaveAsync(cancellationToken);
        return saved > 0
            ? Result<Guid>.SuccessResult(entity.Id, "Başarıyla güncellendi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}
