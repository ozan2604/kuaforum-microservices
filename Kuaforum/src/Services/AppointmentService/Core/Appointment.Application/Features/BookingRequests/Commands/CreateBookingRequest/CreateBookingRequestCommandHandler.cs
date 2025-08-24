using Appointment.Application.Dtos.BookingRequestDtos;
using Appointment.Application.Repositories.BookingRequestRepositories;
using Appointment.Application.Results;
using Appointment.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Appointment.Application.Features.BookingRequests.Commands.CreateBookingRequest;

public class CreateBookingRequestCommandHandler : IRequestHandler<CreateBookingRequestCommandRequest, Result<Guid>>
{
    private readonly IBookingRequestRepository _repository;
    private readonly IMapper _mapper;

    public CreateBookingRequestCommandHandler(IBookingRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateBookingRequestCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<BookingRequest>(request.BookingRequest);
        var added = await _repository.AddAsync(entity, cancellationToken);
        if (!added)
            return Result<Guid>.FailureResult("Ekleme başarısız.");

        var saved = await _repository.SaveAsync(cancellationToken);
        return saved > 0
            ? Result<Guid>.SuccessResult(entity.Id, "Başarıyla eklendi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}
