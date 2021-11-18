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
        /*
        // POST api/AlbumGenres/
        [HttpPost]
        public ActionResult CreateAlbumGenre(AlbumGenreWriteDto AlbumGenreWriteDto)
        {
            AlbumGenre AlbumGenreToCreate = _mapper.Map<AlbumGenre>(AlbumGenreWriteDto);

            if (AlbumGenreToCreate == null)
            {
                throw new ArgumentNullException();
            }

            _repository.CreateAlbumGenre(AlbumGenreToCreate);
            _repository.SaveChanges();

            // return Ok();
            return CreatedAtRoute(nameof(GetAlbumGenreById), new { Id = AlbumGenreToCreate.AlbumGenreId }, AlbumGenreToCreate);
        }

        // PATCH api/AlbumGenres/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateAlbumGenre(int id, JsonPatchDocument<AlbumGenreUpdateDto> patchDoc)
        {
            // Get artist to update
            AlbumGenre AlbumGenreToUpdate = _repository.GetAlbumGenreById(id);

            if (AlbumGenreToUpdate == null)
            {
                return NotFound();
            }

            // Create mapping
            AlbumGenreUpdateDto AlbumGenreUpdateDto = _mapper.Map<AlbumGenreUpdateDto>(AlbumGenreToUpdate);

            // Update artist
            patchDoc.ApplyTo(AlbumGenreUpdateDto, ModelState);

            // Check model validity
            if (!TryValidateModel(AlbumGenreToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            // Update with mapper
            _mapper.Map(AlbumGenreUpdateDto, AlbumGenreToUpdate);

            _repository.UpdateAlbumGenre(AlbumGenreToUpdate);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/AlbumGenres/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteArtist(int id)
        {
            AlbumGenre AlbumGenreToDelete = _repository.GetAlbumGenreById(id);

            if (AlbumGenreToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteAlbumGenre(AlbumGenreToDelete);
            _repository.SaveChanges();

            return NoContent();
        }
        */
    }
}
