﻿using Microsoft.EntityFrameworkCore;
using MultiLayer.Core.Models;
using MultiLayer.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUltiLayer.Data.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        public MusicRepository(MyMusicDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Music>> GetAllWithArtistAsync()
        {
            return await MyMusicDbContext.Musics
                .Include(m => m.Artist)
                .ToListAsync();
        }

        public async Task<Music> GetWithArtistByIdAsync(int id)
        {
            return await MyMusicDbContext.Musics
                .Include(m => m.Artist)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await MyMusicDbContext.Musics
                .Include(m => m.Artist)
                .Where(m => m.ArtistId == artistId)
                .ToListAsync();
        }

        private MyMusicDbContext MyMusicDbContext
        {
            get { return Context as MyMusicDbContext; }
        }
    }
}
