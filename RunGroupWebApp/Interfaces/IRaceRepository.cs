using RunGroupWebApp.Models;


namespace RunGroupWebApp.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetByIdAsync(int id);
        Task<IEnumerable<Race>> GetAllRaceByCity(string city);
        bool Add(Race race);
        bool Update(IRaceRepository race);
        bool Delete(Race race);
        bool Save();
    }
}