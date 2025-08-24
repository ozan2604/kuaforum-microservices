using Application.Results;
using AutoMapper;
using Catalog.Application.Repositories.ServicePhotoRepository;
using Catalog.Application.Services.CurrentUserServices;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.ServicePhotos.Commands.CreateServicePhoto;

public class CreateServicePhotoCommandHandler : IRequestHandler<CreateServicePhotoCommandRequest, Result<Guid>>
{
    private readonly IServicePhotoRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current;

    public CreateServicePhotoCommandHandler(IServicePhotoRepository repository, IMapper mapper, ICurrentUserService current)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
    }

    public async Task<Result<Guid>> Handle(CreateServicePhotoCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ServicePhoto>(request.Photo);
        entity.IsActive = true;
        entity.IsDeleted = false;
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreateUserId = _current.UserId;
        entity.CreateUserName = _current.UserName ?? string.Empty;

        var added = await _repository.AddAsync(entity);
        if (!added)
            return Result<Guid>.FailureResult("Ekleme başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result<Guid>.SuccessResult(entity.Id, "Başarıyla eklendi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}
