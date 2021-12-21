using AlbumStore.Data;
using AlbumStore.DTOs;
using AlbumStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;

namespace AlbumStore.Services
{
    public class AlbumGenreService : IAlbumGenreService
    {
        private readonly IAlbumGenreRepository _repository;
        public AlbumGenreService(IAlbumGenreRepository iRepository)
        {
            _repository = iRepository;
        }
        public IEnumerable<AlbumGenre> GetAllAlbumGenres()
        {
            return _repository.GetAllAlbumGenres();
        }
        public AlbumGenre GetAlbumGenreById(int id)
        {
            return _repository.GetAlbumGenreById(id);
        }        
    }
}
