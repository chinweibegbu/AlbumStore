using AlbumStore.Models;
using AlbumStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlbumStore.Controllers
{
    [ApiController]
    [Route("api/albumGenres")]
    public class AlbumGenreController : ControllerBase
    {
        private readonly IAlbumGenreService _service;

        // Set up repository using dependency injection
        public AlbumGenreController(IAlbumGenreService iService)
        {
            _service = iService;
        }

        // GET api/AlbumGenres/
        [HttpGet]
        public ActionResult<List<AlbumGenre>> GetAllAlbumGenres()
        {
            List<AlbumGenre> albumGenres = (List<AlbumGenre>)_service.GetAllAlbumGenres();
            return Ok(albumGenres);
        }

        // GET api/AlbumGenres/{id}
        [HttpGet("{id}", Name = "GetAlbumGenreById")]
        public ActionResult<AlbumGenre> GetAlbumGenreById(int id)
        {
            AlbumGenre AlbumGenre = _service.GetAlbumGenreById(id);
            
            if (AlbumGenre == null)
            {
                return NotFound();
            }

            return Ok(AlbumGenre);
        }
    }
}
