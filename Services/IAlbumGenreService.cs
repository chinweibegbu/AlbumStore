using AlbumStore.DTOs;
using AlbumStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;

namespace AlbumStore.Services
{
    public interface IAlbumGenreService
    {
        public IEnumerable<AlbumGenre> GetAllAlbumGenres();
        public AlbumGenre GetAlbumGenreById(int id);
    }
}
