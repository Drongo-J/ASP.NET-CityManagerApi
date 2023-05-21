using CityManagerApi.Models;

namespace CityManagerApi.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveAll();
        List<City> GetCities(int userId);
        List<CityImage> GetCityImagesByCityId(int cityId);
        City GetCityById(int cityId);
        CityImage GetCityImageById(int CityImageId);
    }
}
