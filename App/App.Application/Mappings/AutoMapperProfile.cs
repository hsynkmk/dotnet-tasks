using App.Application.DTOs;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Mappings;

internal class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // User Mapping
        CreateMap<User, UserDto>()
            .ReverseMap();

        // Course Mapping
        CreateMap<Course, CourseDto>()
            .ReverseMap();

        // Order Mapping
        CreateMap<Order, OrderDto>()
            .ReverseMap();

        // OrderDetail Mapping
        //CreateMap<OrderDetail, OrderDetailDto>()
        //    .ReverseMap();

        //// Payment Mapping
        //CreateMap<Payment, PaymentDto>()
        //    .ReverseMap();
    }
}
