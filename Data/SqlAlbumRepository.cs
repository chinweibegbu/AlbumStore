using AlbumStore.Models;
using Microsoft.EntityFrameworkCore;
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
            return _context.Albums
                .Include(album => album.Artist)
                .Include(album => album.AlbumGenres)
                .ThenInclude(albumGenre => albumGenre.MusicGenre)
                .ToList();
        }

        public Album GetAlbumById(int id)
        {
            return _context.Albums
                .Include(album => album.Artist)
                .Include(album => album.AlbumGenres)
                .ThenInclude(albumGenre => albumGenre.MusicGenre)
                .FirstOrDefault(a => a.AlbumId == id);
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

        public void DeleteAlbumGenres(int albumId)
        {
            List<AlbumGenre> albumGenresToDelete = _context.AlbumGenres.Where(ag => ag.AlbumId == albumId).ToList();
            foreach (AlbumGenre a in albumGenresToDelete)
            {
                _context.AlbumGenres.Remove(a);
            }
        }

        public IEnumerable<Album> Search(string? name, string[]? genres, string? artist)
        {
            List<Album> matches = new List<Album>();
            List<Album> genreMatches = new List<Album>();

            // Find with matching name and artists
            if ((name != null) && (artist != null))
            {
                matches = _context.Albums
                    .Include(a => a.Artist)
                    .Include(a => a.AlbumGenres)
                    .ThenInclude(albumGenre => albumGenre.MusicGenre)
                    .Where(a => a.AlbumName.Contains(name) && a.Artist.StageName.Contains(artist))
                    .ToList();
            }
            else if ((name == null) && (artist != null))
            {
                matches = _context.Albums
                    .Include(a => a.Artist)
                    .Include(a => a.AlbumGenres)
                    .ThenInclude(albumGenre => albumGenre.MusicGenre)
                    .Where(a => a.Artist.StageName.Contains(artist)).ToList();
            }
            else if ((name != null) && (artist == null))
            {
                matches = _context.Albums
                    .Include(a => a.Artist)
                    .Include(a => a.AlbumGenres)
                    .ThenInclude(albumGenre => albumGenre.MusicGenre)
                    .Where(a => a.AlbumName.Contains(name))
                    .ToList();
            }
            else if ((name == null) && (artist == null)) //If both name and artist are null, return all
            {
                matches = _context.Albums
                    .Include(a => a.Artist)
                    .Include(a => a.AlbumGenres)
                    .ThenInclude(albumGenre => albumGenre.MusicGenre)
                    .ToList();
            }

            if (genres != null)
            {
                foreach (string genre in genres)
                {
                    // Get the ID of the music genre to screen by
                    int musicGenreId = _context.MusicGenres.FirstOrDefault(mg => mg.Name == genre).MusicGenreId;

                    foreach (Album album in matches)
                    {
                        int albumId = album.AlbumId;
                        List<AlbumGenre> albumGenres = album.AlbumGenres;
                       
                        if (albumGenres == null)
                        {
                            continue;
                        }

                        foreach (AlbumGenre albumGenre in albumGenres)
                        {
                            // If there is an entry which has the musicGenreId and album, keep it in
                            if (albumGenre.MusicGenreId == musicGenreId)
                            {
                                if (!genreMatches.Contains(album))
                                {
                                    genreMatches.Add(album);
                                }
                                break;
                            }
                        }
                    }
                }

                return genreMatches;
            }

            return matches;
        }
    }
}
