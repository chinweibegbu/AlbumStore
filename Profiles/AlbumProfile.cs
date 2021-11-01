﻿using AutoMapper;
using AlbumStore.DTOs;
using AlbumStore.Models;

namespace AlbumStore.Profiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<Album, AlbumReadDto>();
            CreateMap<AlbumWriteDto, Album>();
            CreateMap<AlbumUpdateDto, Album>();
            CreateMap<Album, AlbumUpdateDto>();
        }
    }
}