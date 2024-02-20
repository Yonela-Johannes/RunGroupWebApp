using RunGroupWebApp.Data;
using RunGroupWebApp.Models;
using RunGroupWebApp.Interfaces;

namespace RunGroupWebApp.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _context;

        public RaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        bool Add(Race race)
        {
            _context.Add(race);
            return Save();
        }
        bool Update(IClubRepository race)
        {
            _context.Update(race);
            return Save();
        }
        bool Delete(Race race)
        {
            _context.Remove(race);
            return Save();
        }
        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }
        public async Task<Race> GetAllByIdAsync(int id)
        {
            return await _context.Races.Include(i => i.Address).FirstOrDefaultAsync(i => i.id == id);
        }

        public async Task<IEnumerable<Race>> GetClubByCity(string city)
        {
            return await _context.Races.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SavedChanges();
            return saved > 0 ? true : false;
        }
    }
}