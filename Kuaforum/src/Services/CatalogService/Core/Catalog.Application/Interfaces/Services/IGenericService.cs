using Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Interfaces.Services
{
    public interface IGenericService<TDto>
    {
        Task<Result<TDto>> GetByIdAsync(Guid id);
        Task<Result<List<TDto>>> GetAllAsync();
        Task<Result> CreateAsync(TDto dto);
        Task<Result> UpdateAsync(TDto dto);
        Task<Result> DeleteAsync(Guid id);
    }
}
