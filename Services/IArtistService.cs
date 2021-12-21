using AlbumStore.DTOs;
using AlbumStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;

namespace AlbumStore.Services
{
    public interface IArtistService
    {
        public IEnumerable<Artist> GetAllArtists();
        public IEnumerable<Artist> GetAllSoloArtists();
        public Artist GetArtistById(int id);
        public Artist CreateArtist(Artist artist);
        public SoloArtist CreateSoloArtist(SoloArtist soloArtist);
        public void UpdateArtist(Artist artist);
        public void DeleteArtist(Artist artist);
    }
}
