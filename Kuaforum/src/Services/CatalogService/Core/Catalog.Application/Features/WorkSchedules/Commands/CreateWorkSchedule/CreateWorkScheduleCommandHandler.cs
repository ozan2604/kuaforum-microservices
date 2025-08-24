using Application.Results;
using AutoMapper;
using Catalog.Application.Repositories.WorkScheduleRepository;
using Catalog.Application.Services.CurrentUserServices;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.WorkSchedules.Commands.CreateWorkSchedule;

public class CreateWorkScheduleCommandHandler : IRequestHandler<CreateWorkScheduleCommandRequest, Result<Guid>>
{
    private readonly IWorkScheduleRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current;

    public CreateWorkScheduleCommandHandler(IWorkScheduleRepository repository, IMapper mapper, ICurrentUserService current)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
    }

    public async Task<Result<Guid>> Handle(CreateWorkScheduleCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<WorkSchedule>(request.WorkSchedule);
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
