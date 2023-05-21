using CityManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CityManagerApi.Data
{
    public class AppRepository : IAppRepository
    {
        private DataContext _context;

        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<City> GetCities(int userId)
        {
            return _context
                   .Cities
                   .Include(c => c.CityImages)
                   .Where(c => c.UserId == userId)
                   .ToList();
        }

        public City GetCityById(int cityId)
        {
            var city=  _context
                    .Cities
                    .Include(c => c.CityImages)
                    .FirstOrDefault(c => c.Id == cityId);
            return city;
        }

        public CityImage GetCityImageById(int CityImageId)
        {
            return _context
                   .CityImages
                   .FirstOrDefault(c => c.Id == CityImageId);
        }

        public List<CityImage> GetCityImagesByCityId(int cityId)
        {
            return _context
                   .CityImages
                   .Where(p => p.CityId == cityId)
                   .ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
