using AlbumStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlbumStore.Data
{
    class SqlAlbumRepository : IAlbumRepository
    {
        private readonly AlbumStoreContext _context;

        public SqlAlbumRepository(AlbumStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return _context.Albums.Include(album => album.Artist).Include(album => album.AlbumGenres).ToList();
        }

        public Album GetAlbumById(int id)
        {
            return _context.Albums.Include(album => album.Artist).Include(album => album.AlbumGenres).FirstOrDefault(a => a.AlbumId == id);
        }

        public void CreateAlbum(Album album)
        {
            _context.Albums.Add(album);
        }

        public void UpdateAlbum(Album album)
        {
            // Empty
        }

        public void DeleteAlbum(Album album)
        {
            _context.Albums.Remove(album);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void SetGenres(int albumId, string[] genres)
        {
            // Add genres
            foreach (string genre in genres)
            {
                int musicGenreId = _context.MusicGenres.FirstOrDefault(mg => mg.Name == genre).MusicGenreId;     // ID of one genre of new album
                _context.AlbumGenres.Add(new AlbumGenre(albumId, musicGenreId));
            }
        }

        /*
        public IEnumerable<Album> Search(string? name, Genre? genre, string? artist)
        {
            List<Album> matches = new List<Album>();

            if ((name != null) && (genre != null) && (artist != null))
            {
                matches = _context.Albums.Include(a => a.Artist).Where(a => a.AlbumName.Contains(name) && a.Genre == genre && a.Artist.StageName.Contains(artist)).ToList();
            }
            else if ((name == null) && (genre != null) && (artist != null))
            {
                matches = _context.Albums.Include(a => a.Artist).Where(a => a.Genre == genre && a.Artist.StageName.Contains(artist)).ToList();
            }
            else if ((name != null) && (genre == null) && (artist != null))
            {
                matches = _context.Albums.Include(a => a.Artist).Where(a => a.AlbumName.Contains(name) && a.Artist.StageName.Contains(artist)).ToList();
            }
            else if ((name != null) && (genre != null) && (artist == null))
            {
                matches = _context.Albums.Include(a => a.Artist).Where(a => a.AlbumName.Contains(name) && a.Genre == genre).ToList();
            }
            else if ((name != null) && (genre == null) && (artist == null))
            {
                matches = _context.Albums.Include(a => a.Artist).Where(a => a.AlbumName.Contains(name)).ToList();
            }
            else if ((name == null) && (genre != null) && (artist == null))
            {
                matches = _context.Albums.Include(a => a.Artist).Where(a => a.Genre == genre).ToList();
            }
            else if ((name == null) && (genre == null) && (artist != null))
            {
                matches = _context.Albums.Include(a => a.Artist).Where(a => a.Artist.StageName.Contains(artist)).ToList();
            }

            return matches;
        }
        */
    }
}
