using Application.Results;
using Catalog.Application.Dtos.VenueTagDtos;
using MediatR;

namespace Catalog.Application.Features.VenueTags.Commands.CreateVenueTag;

public class CreateVenueTagCommandRequest : IRequest<Result>
{
    public required CreateVenueTagDto VenueTag { get; set; }
}
