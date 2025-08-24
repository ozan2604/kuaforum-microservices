using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.StaffDtos;
using Catalog.Application.Repositories.StaffRepository;
using MediatR;

namespace Catalog.Application.Features.Staffs.Queries.GetStaffById;

public class GetStaffByIdQueryHandler : IRequestHandler<GetStaffByIdQueryRequest, Result<ResultStaffDto>>
{
    private readonly IStaffRepository _repository;
    private readonly IMapper _mapper;

    public GetStaffByIdQueryHandler(IStaffRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultStaffDto>> Handle(GetStaffByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var staff = await _repository.GetByIdAsync(request.Id, false);
        if (staff == null)
            return Result<ResultStaffDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultStaffDto>(staff);
        return Result<ResultStaffDto>.SuccessResult(dto);
    }
}
