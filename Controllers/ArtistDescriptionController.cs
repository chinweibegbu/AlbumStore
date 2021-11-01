using AlbumStore.Data;
using AlbumStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AlbumStore.Controllers
{
    [ApiController]
    [Route("api/artistDescriptions")]
    public class ArtistDescriptionController : ControllerBase
    {
        private readonly IArtistDescriptionRepository _repository;

        // Set up repository using dependency injection
        public ArtistDescriptionController(IArtistDescriptionRepository iRepository)
        {
            _repository = iRepository;
        }

        // GET api/artistDescriptions/
        [HttpGet]
        public ActionResult<List<Album>> GetAllArtistDescriptions()
        {
            return Ok(_repository.GetAllArtistDescriptions());
        }

        // GET api/artistDescriptions/{id}
        [HttpGet("{id}")]
        public ActionResult<ArtistDescription> GetArtistDescriptionById(int id)
        {
            ArtistDescription artistDescription = _repository.GetArtistDescriptionById(id);
            
            if (artistDescription == null)
            {
                return NotFound();
            }

            return Ok(artistDescription);
        }

        // POST api/artistDescriptions/
        [HttpPost]
        public ActionResult CreateArtistDescription(ArtistDescription artistDescription)
        {
            ArtistDescription artistDescriptionToCreate = artistDescription;

            if (artistDescriptionToCreate == null)
            {
                throw new ArgumentNullException();
            }

            _repository.CreateArtistDescription(artistDescriptionToCreate);
            _repository.SaveChanges();
            
            return Ok();
        }

        // PATCH api/artistDescriptions/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateArtistDescription(int id, JsonPatchDocument<ArtistDescription> patchDoc)
        {
            // Get artist to update
            ArtistDescription artistDescriptionToUpdate = _repository.GetArtistDescriptionById(id);

            if (artistDescriptionToUpdate == null)
            {
                return NotFound();
            }

            // Update artist
            patchDoc.ApplyTo(artistDescriptionToUpdate, ModelState);

            // Check model validity
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            _repository.UpdateArtistDescription(artistDescriptionToUpdate);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/artistDescriptions/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteArtist(int id)
        {
            ArtistDescription artistDescriptionToDelete = _repository.GetArtistDescriptionById(id);

            if (artistDescriptionToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteArtistDescription(artistDescriptionToDelete);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
