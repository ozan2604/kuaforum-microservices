using Appointment.Application.Dtos.AppointmentHistoryDtos;
using Appointment.Application.Repositories.AppointmentHistoryRepositories;
using Appointment.Application.Results;
using AutoMapper;
using MediatR;

namespace Appointment.Application.Features.AppointmentHistories.Queries.GetAppointmentHistoryById;

public class GetAppointmentHistoryByIdQueryHandler : IRequestHandler<GetAppointmentHistoryByIdQueryRequest, Result<ResultAppointmentHistoryDto>>
{
    private readonly IAppointmentHistoryRepository _repository;
    private readonly IMapper _mapper;

    public GetAppointmentHistoryByIdQueryHandler(IAppointmentHistoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultAppointmentHistoryDto>> Handle(GetAppointmentHistoryByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var history = await _repository.GetByIdAsync(request.Id);
        if (history == null)
            return Result<ResultAppointmentHistoryDto>.FailureResult("Kayıt bulunamadı.");
        var dto = _mapper.Map<ResultAppointmentHistoryDto>(history);
        return Result<ResultAppointmentHistoryDto>.SuccessResult(dto);
    }
}
