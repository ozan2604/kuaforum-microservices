using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Services.CatalogServices
{
    public interface ICatalogService
    {
        Task<CatalogVenueDto?> GetVenueAsync(Guid id, CancellationToken cancellationToken = default);
        Task<CatalogStaffDto?> GetStaffAsync(Guid id, CancellationToken cancellationToken = default);
        Task<CatalogServiceDto?> GetServiceAsync(Guid id, CancellationToken cancellationToken = default);
    }

    public record CatalogVenueDto(Guid Id, string Name);
    public record CatalogStaffDto(Guid Id, string Name);
    public record CatalogServiceDto(Guid Id, string Name, int Duration, decimal Price);
}
