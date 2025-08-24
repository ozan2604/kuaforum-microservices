using System;
namespace Catalog.Application.Dtos.ReviewDtos;

public class UpdateReviewDto : CreateReviewDto
{
    public Guid Id { get; set; }
}
