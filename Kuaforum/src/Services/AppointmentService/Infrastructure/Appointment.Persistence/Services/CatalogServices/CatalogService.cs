using Appointment.Application.Results;
using Appointment.Application.Services.CatalogServices;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Persistence.Services.CatalogServices
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CatalogVenueDto?> GetVenueAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _client.GetFromJsonAsync<Result<CatalogVenueDto>>($"catalog/Venues/{id}", cancellationToken);
            return result?.Data;
        }

        public async Task<CatalogStaffDto?> GetStaffAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _client.GetFromJsonAsync<Result<CatalogStaffDto>>($"catalog/Staffs/{id}", cancellationToken);
            return result?.Data;
        }

        public async Task<CatalogServiceDto?> GetServiceAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _client.GetFromJsonAsync<Result<CatalogServiceDto>>($"catalog/Services/{id}", cancellationToken);
            return result?.Data;
        }
    }
}
