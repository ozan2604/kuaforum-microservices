using System;
using System.Net.Http.Json;
using Appointment.Application.Dtos.CatalogDtos;
using Appointment.Application.Interfaces.Services;

namespace Appointment.Persistence.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatalogInfoDto> GetCatalogInfoAsync(Guid venueId, Guid staffId, Guid serviceId, CancellationToken cancellationToken)
        {
            try
            {
                // Placeholder implementation - replace with real HTTP calls to Catalog service
                var response = await _httpClient.GetFromJsonAsync<CatalogInfoDto>($"api/catalog/snapshot?venueId={venueId}&staffId={staffId}&serviceId={serviceId}", cancellationToken);
                if (response != null)
                    return response;
            }
            catch
            {
                // swallow exceptions for placeholder
            }

            // Fallback dummy data
            return new CatalogInfoDto
            {
                VenueName = $"Venue-{venueId}",
                StaffName = $"Staff-{staffId}",
                ServiceName = $"Service-{serviceId}",
                DurationMinutes = 60,
                Price = 0m,
                Currency = "TRY"
            };
        }
    }
}
