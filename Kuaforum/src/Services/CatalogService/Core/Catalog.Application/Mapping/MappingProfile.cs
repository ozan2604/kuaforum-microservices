using AutoMapper;
using Catalog.Application.Dtos.VenueDtos;
using Catalog.Application.Dtos.TagDtos;
using Catalog.Application.Dtos.ServiceDtos;
using Catalog.Application.Dtos.StaffDtos;
using Catalog.Application.Dtos.ReviewDtos;
using Catalog.Application.Dtos.LikeDtos;
using Catalog.Application.Dtos.HolidayDtos;
using Catalog.Application.Dtos.WorkScheduleDtos;
using Catalog.Application.Dtos.StaffTimeOffDtos;
using Catalog.Application.Dtos.VenueTagDtos;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VenueDto, Venue>().ReverseMap();
            CreateMap<CreateVenueDto, Venue>().ReverseMap();
            CreateMap<UpdateVenueDto, Venue>().ReverseMap();
            CreateMap<ResultVenueDto, Venue>().ReverseMap();

            CreateMap<TagDto, Tag>().ReverseMap();
            CreateMap<CreateTagDto, Tag>().ReverseMap();
            CreateMap<UpdateTagDto, Tag>().ReverseMap();
            CreateMap<ResultTagDto, Tag>().ReverseMap();

            CreateMap<ServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<ResultServiceDto, Service>().ReverseMap();

            CreateMap<StaffDto, Staff>().ReverseMap();
            CreateMap<CreateStaffDto, Staff>().ReverseMap();
            CreateMap<UpdateStaffDto, Staff>().ReverseMap();
            CreateMap<ResultStaffDto, Staff>().ReverseMap();

            CreateMap<ReviewDto, Review>().ReverseMap();
            CreateMap<CreateReviewDto, Review>().ReverseMap();
            CreateMap<UpdateReviewDto, Review>().ReverseMap();
            CreateMap<ResultReviewDto, Review>().ReverseMap();

            CreateMap<LikeDto, Like>().ReverseMap();
            CreateMap<CreateLikeDto, Like>().ReverseMap();
            CreateMap<UpdateLikeDto, Like>().ReverseMap();
            CreateMap<ResultLikeDto, Like>().ReverseMap();

            CreateMap<HolidayDto, Holiday>().ReverseMap();
            CreateMap<CreateHolidayDto, Holiday>().ReverseMap();
            CreateMap<UpdateHolidayDto, Holiday>().ReverseMap();
            CreateMap<ResultHolidayDto, Holiday>().ReverseMap();

            CreateMap<WorkScheduleDto, WorkSchedule>().ReverseMap();
            CreateMap<CreateWorkScheduleDto, WorkSchedule>().ReverseMap();
            CreateMap<UpdateWorkScheduleDto, WorkSchedule>().ReverseMap();
            CreateMap<ResultWorkScheduleDto, WorkSchedule>().ReverseMap();


            CreateMap<StaffTimeOffDto, StaffTimeOff>().ReverseMap();
            CreateMap<CreateStaffTimeOffDto, StaffTimeOff>().ReverseMap();
            CreateMap<UpdateStaffTimeOffDto, StaffTimeOff>().ReverseMap();
            CreateMap<ResultStaffTimeOffDto, StaffTimeOff>().ReverseMap();

            CreateMap<VenueTagDto, VenueTag>().ReverseMap();
            CreateMap<CreateVenueTagDto, VenueTag>().ReverseMap();
            CreateMap<ResultVenueTagDto, VenueTag>().ReverseMap();
        }
    }
}
