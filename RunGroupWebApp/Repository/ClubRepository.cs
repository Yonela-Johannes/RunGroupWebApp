using RunGroupWebApp.Data;
using RunGroupWebApp.Models;
using RunGroupWebApp.Interfaces;

namespace RunGroupWebApp.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        bool Add(Club club)
        {
            _context.Add(club);
            return Save();
        }
        bool Update(IClubRepository club)
        {
            _context.Update(club);
            return Save();
        }
        bool Delete(Club club)
        {
            _context.Remove(club);
            return Save();
        }
        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
        }
        public async Task<Club> GetAllByIdAsync(int id)
        {
            return await _context.Clubs.Include(i => i.Address).FirstOrDefaultAsync(i => i.id == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Clubs.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SavedChanges();
            return saved > 0 ? true : false;
        }
    }
}