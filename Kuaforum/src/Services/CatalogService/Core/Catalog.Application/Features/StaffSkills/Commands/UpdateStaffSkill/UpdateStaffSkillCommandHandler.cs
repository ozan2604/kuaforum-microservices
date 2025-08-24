using Application.Results;
using AutoMapper;
using Catalog.Application.Repositories.StaffSkillRepository;
using Catalog.Application.Services.CurrentUserServices;
using MediatR;

namespace Catalog.Application.Features.StaffSkills.Commands.UpdateStaffSkill;

public class UpdateStaffSkillCommandHandler : IRequestHandler<UpdateStaffSkillCommandRequest, Result>
{
    private readonly IStaffSkillRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current;

    public UpdateStaffSkillCommandHandler(IStaffSkillRepository repository, IMapper mapper, ICurrentUserService current)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
    }

    public async Task<Result> Handle(UpdateStaffSkillCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Skill.Id);
        if (entity == null)
            return Result.FailureResult("Güncellenecek veri bulunamadı.");

        entity = _mapper.Map(request.Skill, entity);
        entity.UpdateUserId = _current.UserId;
        entity.UpdateUserName = _current.UserName ?? string.Empty;
        entity.UpdatedAt = DateTime.UtcNow;

        var updated = _repository.Update(entity);
        if (!updated)
            return Result.FailureResult("Güncelleme başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result.SuccessResult("Başarıyla güncellendi.")
            : Result.FailureResult("Veritabanına kaydedilemedi.");
    }
}
