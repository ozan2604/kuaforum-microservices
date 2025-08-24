using AutoMapper;
using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Dtos.AppointmentHistoryDtos;
using Appointment.Application.Dtos.BookingRequestDtos;
using Appointment.Domain.Entities;

namespace Appointment.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AppointmentDto, Appointment.Domain.Entities.Appointment>().ReverseMap();
        CreateMap<CreateAppointmentDto, Appointment.Domain.Entities.Appointment>().ReverseMap();
        CreateMap<UpdateAppointmentDto, Appointment.Domain.Entities.Appointment>().ReverseMap();
        CreateMap<ResultAppointmentDto, Appointment.Domain.Entities.Appointment>().ReverseMap();

        CreateMap<AppointmentHistoryDto, AppointmentHistory>().ReverseMap();
        CreateMap<CreateAppointmentHistoryDto, AppointmentHistory>().ReverseMap();
        CreateMap<UpdateAppointmentHistoryDto, AppointmentHistory>().ReverseMap();
        CreateMap<ResultAppointmentHistoryDto, AppointmentHistory>().ReverseMap();

        CreateMap<BookingRequestDto, BookingRequest>().ReverseMap();
        CreateMap<CreateBookingRequestDto, BookingRequest>().ReverseMap();
        CreateMap<UpdateBookingRequestDto, BookingRequest>().ReverseMap();
        CreateMap<ResultBookingRequestDto, BookingRequest>().ReverseMap();
    }
}
