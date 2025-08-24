using Appointment.Application.Dtos.AppointmentHistoryDtos;
using Appointment.Application.Repositories.AppointmentHistoryRepositories;
using Appointment.Application.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Application.Features.AppointmentHistories.Queries.GetAppointmentHistories;

public class GetAppointmentHistoriesQueryHandler : IRequestHandler<GetAppointmentHistoriesQueryRequest, Result<List<ResultAppointmentHistoryDto>>>
{
    private readonly IAppointmentHistoryRepository _repository;
    private readonly IMapper _mapper;

    public GetAppointmentHistoriesQueryHandler(IAppointmentHistoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultAppointmentHistoryDto>>> Handle(GetAppointmentHistoriesQueryRequest request, CancellationToken cancellationToken)
    {
        var histories = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultAppointmentHistoryDto>>(histories);
        return Result<List<ResultAppointmentHistoryDto>>.SuccessResult(dtoList);
    }
}
