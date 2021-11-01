using AlbumStore.Data;
using AlbumStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public ActionResult<List<Album>> GetAllAlbums()
        {
            return Ok(_repository.GetAllAlbums());
        }

        // GET api/albums/{id}
        [HttpGet("{id}")]
        public ActionResult<Album> GetAlbumById(int id)
        {
            Album album = _repository.GetAlbumById(id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        // GET api/albums/{album}

        // POST api/albums/
        [HttpPost]
        public ActionResult CreateAlbum(Album album)
        {
            Album albumToCreate = album;

            if (albumToCreate == null)
            {
                throw new ArgumentNullException();
            }

            _repository.CreateAlbum(albumToCreate);
            _repository.SaveChanges();

            return Ok();
        }

        // PATCH api/albums/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateAlbum(int id, JsonPatchDocument<Album> patchDoc)
        {
            // Get album to update
            Album albumToUpdate = _repository.GetAlbumById(id);

            if (albumToUpdate == null)
            {
                return NotFound();
            }

            // Update album
            patchDoc.ApplyTo(albumToUpdate, ModelState);

            // Check model validity
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            _repository.UpdateAlbum(albumToUpdate);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/albums/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAlbum(int id)
        {
            Album albumToDelete = _repository.GetAlbumById(id);

            if (albumToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteAlbum(albumToDelete);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
