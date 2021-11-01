using AutoMapper;
using AlbumStore.DTOs;
using AlbumStore.Models;

namespace AlbumStore.Profiles
{
    public class ArtistDescriptionProfile : Profile
    {
        public ArtistDescriptionProfile()
        {
            CreateMap<ArtistDescription, ArtistDescriptionReadDto>();
            CreateMap<ArtistDescriptionWriteDto, ArtistDescription>();
            CreateMap<ArtistDescriptionUpdateDto, ArtistDescription>();
            CreateMap<ArtistDescription, ArtistDescriptionUpdateDto>();
        }
    }
}
