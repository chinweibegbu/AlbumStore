using AlbumStore.Data;
using AlbumStore.DTOs;
using AlbumStore.Models;
using AlbumStore.Services;
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
        private readonly IMapper _mapper;
        private readonly IArtistDescriptionService _service;

        // Set up repository using dependency injection
        public ArtistDescriptionController(IMapper iMapper, IArtistDescriptionService iService)
        {
            _mapper = iMapper;
            _service = iService;
        }

        // GET api/artistDescriptions/
        [HttpGet]
        public ActionResult<List<ArtistDescriptionReadDto>> GetAllArtistDescriptions()
        {
            List<ArtistDescription> artistDescriptions = (List<ArtistDescription>)_service.GetAllArtistDescriptions();
            List<ArtistDescriptionReadDto> artistDescriptionReadDtos = _mapper.Map<List<ArtistDescriptionReadDto>>(artistDescriptions);
            
            return Ok(artistDescriptionReadDtos);
        }

        // GET api/artistDescriptions/{id}
        [HttpGet("{id}", Name = "GetArtistDescriptionById")]
        public ActionResult<ArtistDescriptionReadDto> GetArtistDescriptionById(int id)
        {
            ArtistDescription artistDescription = _service.GetArtistDescriptionById(id);
            
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

            ArtistDescription createdArtistDescription = _service.CreateArtistDescription(artistDescriptionToCreate);

            return CreatedAtRoute(nameof(GetArtistDescriptionById), new { Id = artistDescriptionToCreate.ArtistDescriptionId }, createdArtistDescription);
        }

        // PATCH api/artistDescriptions/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateArtistDescription(int id, JsonPatchDocument<ArtistDescriptionUpdateDto> patchDoc)
        {
            // Get artist to update
            ArtistDescription artistDescriptionToUpdate = _service.GetArtistDescriptionById(id);

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

            _service.UpdateArtistDescription(artistDescriptionToUpdate);

            return NoContent();
        }

        // DELETE api/artistDescriptions/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteArtistDescription(int id)
        {
            ArtistDescription artistDescriptionToDelete = _service.GetArtistDescriptionById(id);

            if (artistDescriptionToDelete == null)
            {
                return NotFound();
            }

            _service.DeleteArtistDescription(artistDescriptionToDelete);

            return NoContent();
        }
    }
}
