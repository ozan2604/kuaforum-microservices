using Appointment.Application.Dtos.BookingRequestDtos;
using Appointment.Application.Repositories.BookingRequestRepositories;
using Appointment.Application.Results;
using AutoMapper;
using MediatR;

namespace Appointment.Application.Features.BookingRequests.Commands.UpdateBookingRequest;

public class UpdateBookingRequestCommandHandler : IRequestHandler<UpdateBookingRequestCommandRequest, Result<Guid>>
{
    private readonly IBookingRequestRepository _repository;
    private readonly IMapper _mapper;

    public UpdateBookingRequestCommandHandler(IBookingRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(UpdateBookingRequestCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.BookingRequest.Id);
        if (entity == null)
            return Result<Guid>.FailureResult("Kayıt bulunamadı.");

        _mapper.Map(request.BookingRequest, entity);
        var updated = _repository.Update(entity);
        if (!updated)
            return Result<Guid>.FailureResult("Güncelleme başarısız.");

        var saved = await _repository.SaveAsync(cancellationToken);
        return saved > 0
            ? Result<Guid>.SuccessResult(entity.Id, "Başarıyla güncellendi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}
