using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.ServiceDtos;
using Catalog.Application.Repositories.ServiceRepository;
using MediatR;

namespace Catalog.Application.Features.Services.Queries.GetServiceById;

public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQueryRequest, Result<ResultServiceDto>>
{
    private readonly IServiceRepository _repository;
    private readonly IMapper _mapper;

    public GetServiceByIdQueryHandler(IServiceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultServiceDto>> Handle(GetServiceByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.Id, false);
        if (service == null)
            return Result<ResultServiceDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultServiceDto>(service);
        return Result<ResultServiceDto>.SuccessResult(dto);
    }
}
