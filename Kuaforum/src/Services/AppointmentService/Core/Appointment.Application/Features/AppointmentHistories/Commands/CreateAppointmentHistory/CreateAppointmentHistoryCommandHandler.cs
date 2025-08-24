using Appointment.Application.Dtos.AppointmentHistoryDtos;
using Appointment.Application.Repositories.AppointmentHistoryRepositories;
using Appointment.Application.Results;
using Appointment.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Appointment.Application.Features.AppointmentHistories.Commands.CreateAppointmentHistory;

public class CreateAppointmentHistoryCommandHandler : IRequestHandler<CreateAppointmentHistoryCommandRequest, Result<Guid>>
{
    private readonly IAppointmentHistoryRepository _repository;
    private readonly IMapper _mapper;

    public CreateAppointmentHistoryCommandHandler(IAppointmentHistoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateAppointmentHistoryCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<AppointmentHistory>(request.History);
        var added = await _repository.AddAsync(entity, cancellationToken);
        if (!added)
            return Result<Guid>.FailureResult("Ekleme başarısız.");

        var saved = await _repository.SaveAsync(cancellationToken);
        return saved > 0
            ? Result<Guid>.SuccessResult(entity.Id, "Başarıyla eklendi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}
