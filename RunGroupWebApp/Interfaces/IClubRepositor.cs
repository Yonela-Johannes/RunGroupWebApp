using RunGroupWebApp.Models;


namespace RunGroupWebApp.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAll();
        Task<IEnumerable<Club>> GetClubByCity(string city);
        bool Add(Club club);
        bool Update(IClubRepository club);
        bool Delete(Club club);
        bool Save();
    }
}