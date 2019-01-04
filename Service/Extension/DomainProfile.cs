﻿using AutoMapper;
using Data.Entity;
using Service.dto;
using Service.DTO;

namespace Service
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Flat, FlatViewModel>();
            CreateMap<Location, LocationViewModel>();
            CreateMap<HouseRules, HouseRulesViewModel>();
            CreateMap<Amenties, AmenitiesViewModel>();
            CreateMap<Image, ImageViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderedFlatViewModel, Order>();
            CreateMap<User, ProfileViewModel>();
            CreateMap<UserRegistrationParamsViewModel, User>();
            CreateMap<Message, MessageViewModel>();
        }
    }
}