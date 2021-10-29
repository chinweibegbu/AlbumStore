using AlbumStore.Data;
using AlbumStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlbumStore.Controllers
{
    [ApiController]
    [Route("api/albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _repository;

        // Set up repository using dependency injection
        public AlbumController(IAlbumRepository iRepository)
        {
            _repository = iRepository;
        }

        // GET api/albums/
        [HttpGet]
        public ActionResult<List<Album>> GetAllArtists()
        {
            return Ok(_repository.GetAllAlbums());
        }

        // GET api/albums/{id}

        // GET api/albums/{artist}

        // POST api/albums/

        // PATCH api/albums/{id}

        // DELETE api/albums/{id}
    }
}
