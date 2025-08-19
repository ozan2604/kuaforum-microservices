using Appointment.Application.Repositories;
using Appointment.Application.Results;
using Appointment.Application.Services;
using Appointment.Domain.Entities.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Persistence.Services
{
    public class GenericService<T, TDto, TCreateDto, TUpdateDto> : IGenericService<TDto, TCreateDto, TUpdateDto>
    where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result> CreateAsync(TCreateDto dto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<T>(dto);
            entity.CreateAt = DateTime.UtcNow;

            var result = await _repository.AddAsync(entity);
            if (!result)
                return Result.FailureResult("Ekleme başarısız.");



            var saved = await _repository.SaveAsync();
            return saved > 0
                ? Result.SuccessResult("Başarıyla eklendi.")
                : Result.FailureResult("Veritabanına kaydedilemedi.");
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return Result.FailureResult("Silinecek veri bulunamadı.");

            var result = _repository.Remove(entity);
            if (!result)
                return Result.FailureResult("Silme başarısız.");

            var saved = await _repository.SaveAsync();
            return saved > 0
                ? Result.SuccessResult("Başarıyla silindi.")
                : Result.FailureResult("Veritabanına silme yansıtılamadı.");
        }

        public async Task<Result<List<TDto>>> GetAllAsync()
        {
            var list = await _repository.GetAll(false).ToListAsync();
            var dtoList = _mapper.Map<List<TDto>>(list);
            return Result<List<TDto>>.SuccessResult(dtoList);
        }

        public async Task<Result<TDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id, false);
            if (entity == null)
                return Result<TDto>.FailureResult("Kayıt bulunamadı.");

            var dto = _mapper.Map<TDto>(entity);
            return Result<TDto>.SuccessResult(dto);
        }

        public async Task<Result> UpdateAsync(TUpdateDto dto)
        {
            var idProp = typeof(TDto).GetProperty("Id");
            if (idProp == null)
                return Result.FailureResult("Id bulunamadı.");

            var id = (Guid)idProp.GetValue(dto);
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return Result.FailureResult("Güncellenecek veri bulunamadı.");

            _mapper.Map(dto, entity);
            entity.UpdateAt = DateTime.UtcNow;

            var result = _repository.Update(entity);
            if (!result)
                return Result.FailureResult("Güncelleme başarısız.");

            var saved = await _repository.SaveAsync();
            return saved > 0
                ? Result.SuccessResult("Başarıyla güncellendi.")
                : Result.FailureResult("Veritabanına güncelleme yansıtılamadı.");
        }
    }
}
