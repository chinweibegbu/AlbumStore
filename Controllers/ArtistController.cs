using AlbumStore.Data;
using AlbumStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AlbumStore.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _repository;

        // Set up repository using dependency injection
        public ArtistController(IArtistRepository iRepository)
        {
            _repository = iRepository;
        }

        // GET api/artists/
        [HttpGet]
        public ActionResult<List<Album>> GetAllArtists()
        {
            return Ok(_repository.GetAllArtists());
        }

        // GET api/artists/solo
        [HttpGet("solo")]
        public ActionResult<List<Album>> GetAllSoloArtists()
        {
            return Ok(_repository.GetAllSoloArtists());
        }

        // GET api/artists/{id}
        [HttpGet("{id}")]
        public ActionResult<Artist> GetArtistById(int id)
        {
            Artist artist= _repository.GetArtistById(id);
            
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // GET api/artists/{artist}

        // POST api/artists/
        [HttpPost]
        public ActionResult CreateArtist(Artist artist)
        {
            Artist artistToCreate = artist;

            if (artistToCreate == null)
            {
                throw new ArgumentNullException();
            }

            _repository.CreateArtist(artistToCreate);
            _repository.SaveChanges();
            
            return Ok();
        }

        // POST api/artists/solo
        [HttpPost("solo")]
        public ActionResult CreateSoloArtist(SoloArtist artist)
        {
            SoloArtist soloArtistToCreate = artist;

            if (soloArtistToCreate == null)
            {
                throw new ArgumentNullException();
            }

            _repository.CreateSoloArtist(soloArtistToCreate);
            _repository.SaveChanges();

            return Ok();
        }

        // PATCH api/artists/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateArtist(int id, JsonPatchDocument<Artist> patchDoc)
        {
            // Get artist to update
            Artist artistToUpdate = _repository.GetArtistById(id);

            if (artistToUpdate == null)
            {
                return NotFound();
            }

            // Update artist
            patchDoc.ApplyTo(artistToUpdate, ModelState);

            // Check model validity
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            _repository.UpdateArtist(artistToUpdate);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/artists/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteArtist(int id)
        {
            Artist artistToDelete = _repository.GetArtistById(id);

            if (artistToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteArtist(artistToDelete);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
