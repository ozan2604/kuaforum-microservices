using Appointment.Application.Dtos.CatalogDtos;

namespace Appointment.Application.Interfaces.Services
{
    public interface ICatalogService
    {
        Task<CatalogInfoDto> GetCatalogInfoAsync(Guid venueId, Guid staffId, Guid serviceId, CancellationToken cancellationToken);
    }
}
