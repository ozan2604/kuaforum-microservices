using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.StaffDtos;
using Catalog.Application.Repositories.StaffRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.Staffs.Queries.GetStaffs;

public class GetStaffsQueryHandler : IRequestHandler<GetStaffsQueryRequest, Result<List<ResultStaffDto>>>
{
    private readonly IStaffRepository _repository;
    private readonly IMapper _mapper;

    public GetStaffsQueryHandler(IStaffRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultStaffDto>>> Handle(GetStaffsQueryRequest request, CancellationToken cancellationToken)
    {
        var staffs = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultStaffDto>>(staffs);
        return Result<List<ResultStaffDto>>.SuccessResult(dtoList);
    }
}
