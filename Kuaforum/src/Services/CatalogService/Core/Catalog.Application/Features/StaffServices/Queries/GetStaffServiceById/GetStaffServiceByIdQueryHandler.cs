using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.StaffServiceDtos;
using Catalog.Application.Repositories.StaffServiceRepository;
using MediatR;

namespace Catalog.Application.Features.StaffServices.Queries.GetStaffServiceById;

public class GetStaffServiceByIdQueryHandler : IRequestHandler<GetStaffServiceByIdQueryRequest, Result<ResultStaffServiceDto>>
{
    private readonly IStaffServiceRepository _repository;
    private readonly IMapper _mapper;

    public GetStaffServiceByIdQueryHandler(IStaffServiceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultStaffServiceDto>> Handle(GetStaffServiceByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, false);
        if (entity == null)
            return Result<ResultStaffServiceDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultStaffServiceDto>(entity);
        return Result<ResultStaffServiceDto>.SuccessResult(dto);
    }
}
