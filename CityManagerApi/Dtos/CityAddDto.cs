using CityManagerApi.Models;

namespace CityManagerApi.Dtos
{
    public class CityAddDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
