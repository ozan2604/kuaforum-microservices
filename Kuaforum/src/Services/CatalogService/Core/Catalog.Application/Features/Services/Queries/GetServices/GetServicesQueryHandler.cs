using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.ServiceDtos;
using Catalog.Application.Repositories.ServiceRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.Services.Queries.GetServices;

public class GetServicesQueryHandler : IRequestHandler<GetServicesQueryRequest, Result<List<ResultServiceDto>>>
{
    private readonly IServiceRepository _repository;
    private readonly IMapper _mapper;

    public GetServicesQueryHandler(IServiceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultServiceDto>>> Handle(GetServicesQueryRequest request, CancellationToken cancellationToken)
    {
        var services = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultServiceDto>>(services);
        return Result<List<ResultServiceDto>>.SuccessResult(dtoList);
    }
}
