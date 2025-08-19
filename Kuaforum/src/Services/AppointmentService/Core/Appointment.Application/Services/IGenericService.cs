using Appointment.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Services
{
    public interface IGenericService<TDto, TCreateDto, TUpdateDto>
    {
        Task<Result<TDto>> GetByIdAsync(Guid id);
        Task<Result<List<TDto>>> GetAllAsync();
        Task<Result> CreateAsync(TCreateDto dto, CancellationToken cancellationToken);
        Task<Result> UpdateAsync(TUpdateDto dto);
        Task<Result> DeleteAsync(Guid id);
    }
}
