using AutoMapper;
using AlbumStore.DTOs;
using AlbumStore.Models;

namespace AlbumStore.Profiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, ArtistReadDto>();
            CreateMap<SoloArtist, SoloArtistReadDto>();
            CreateMap<ArtistWriteDto, Artist>();
            CreateMap<SoloArtistWriteDto, SoloArtist>();
            CreateMap<ArtistUpdateDto, Artist>();
            CreateMap<SoloArtistUpdateDto, SoloArtist>();
            CreateMap<Artist, ArtistUpdateDto>();
            CreateMap<SoloArtist, SoloArtistUpdateDto>();
        }
    }
}
