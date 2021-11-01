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
    [Route("api/artistDescriptions")]
    public class ArtistDescriptionController : ControllerBase
    {
        private readonly IArtistDescriptionRepository _repository;
        private readonly IMapper _mapper;

        // Set up repository using dependency injection
        public ArtistDescriptionController(IArtistDescriptionRepository iRepository, IMapper iMapper)
        {
            _repository = iRepository;
            _mapper = iMapper;
        }

        // GET api/artistDescriptions/
        [HttpGet]
        public ActionResult<List<ArtistDescriptionReadDto>> GetAllArtistDescriptions()
        {
            List<ArtistDescription> artistDescriptions = (List<ArtistDescription>)_repository.GetAllArtistDescriptions();
            List<ArtistDescriptionReadDto> artistDescriptionReadDtos = _mapper.Map<List<ArtistDescriptionReadDto>>(_repository.GetAllArtistDescriptions());
            return Ok(artistDescriptionReadDtos);
        }

        // GET api/artistDescriptions/{id}
        [HttpGet("{id}", Name = "GetArtistDescriptionById")]
        public ActionResult<ArtistDescriptionReadDto> GetArtistDescriptionById(int id)
        {
            ArtistDescription artistDescription = _repository.GetArtistDescriptionById(id);
            
            if (artistDescription == null)
            {
                return NotFound();
            }

            ArtistDescriptionReadDto artistDescriptionReadDto = _mapper.Map<ArtistDescriptionReadDto>(artistDescription);

            return Ok(artistDescriptionReadDto);
        }

        // POST api/artistDescriptions/
        [HttpPost]
        public ActionResult CreateArtistDescription(ArtistDescriptionWriteDto artistDescriptionWriteDto)
        {
            ArtistDescription artistDescriptionToCreate = _mapper.Map<ArtistDescription>(artistDescriptionWriteDto);

            if (artistDescriptionToCreate == null)
            {
                throw new ArgumentNullException();
            }

            _repository.CreateArtistDescription(artistDescriptionToCreate);
            _repository.SaveChanges();

            // return Ok();
            return CreatedAtRoute(nameof(GetArtistDescriptionById), new { Id = artistDescriptionToCreate.ArtistDescriptionId }, artistDescriptionToCreate);
        }

        // PATCH api/artistDescriptions/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateArtistDescription(int id, JsonPatchDocument<ArtistDescriptionUpdateDto> patchDoc)
        {
            // Get artist to update
            ArtistDescription artistDescriptionToUpdate = _repository.GetArtistDescriptionById(id);

            if (artistDescriptionToUpdate == null)
            {
                return NotFound();
            }

            // Create mapping
            ArtistDescriptionUpdateDto artistDescriptionUpdateDto = _mapper.Map<ArtistDescriptionUpdateDto>(artistDescriptionToUpdate);

            // Update artist
            patchDoc.ApplyTo(artistDescriptionUpdateDto, ModelState);

            // Check model validity
            if (!TryValidateModel(artistDescriptionToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            // Update with mapper
            _mapper.Map(artistDescriptionUpdateDto, artistDescriptionToUpdate);

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
