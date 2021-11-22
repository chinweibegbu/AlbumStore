using AlbumStore.Data;
using AlbumStore.DTOs;
using AlbumStore.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AlbumStore.Controllers
{
    [ApiController]
    [Route("api/albumGenres")]
    public class AlbumGenreController : ControllerBase
    {
        private readonly IAlbumGenreRepository _repository;

        // Set up repository using dependency injection
        public AlbumGenreController(IAlbumGenreRepository iRepository)
        {
            _repository = iRepository;
        }

        // GET api/AlbumGenres/
        [HttpGet]
        public ActionResult<List<AlbumGenre>> GetAllAlbumGenres()
        {
            List<AlbumGenre> albumGenres = (List<AlbumGenre>)_repository.GetAllAlbumGenres();
            return Ok(albumGenres);
        }

        // GET api/AlbumGenres/{id}
        [HttpGet("{id}", Name = "GetAlbumGenreById")]
        public ActionResult<AlbumGenre> GetAlbumGenreById(int id)
        {
            AlbumGenre AlbumGenre = _repository.GetAlbumGenreById(id);
            
            if (AlbumGenre == null)
            {
                return NotFound();
            }

            return Ok(AlbumGenre);
        }
    }
}
