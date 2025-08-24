using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.StaffServiceDtos;
using Catalog.Application.Repositories.StaffServiceRepository;
using MediatR;

namespace Catalog.Application.Features.StaffServices.Queries.GetStaffServices;

public class GetStaffServicesQueryHandler : IRequestHandler<GetStaffServicesQueryRequest, Result<List<ResultStaffServiceDto>>>
{
    private readonly IStaffServiceRepository _repository;
    private readonly IMapper _mapper;

    public GetStaffServicesQueryHandler(IStaffServiceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultStaffServiceDto>>> Handle(GetStaffServicesQueryRequest request, CancellationToken cancellationToken)
    {
        var entities =  _repository.GetAll(false);
        var dtos = _mapper.Map<List<ResultStaffServiceDto>>(entities);
        return Result<List<ResultStaffServiceDto>>.SuccessResult(dtos);
    }
}
