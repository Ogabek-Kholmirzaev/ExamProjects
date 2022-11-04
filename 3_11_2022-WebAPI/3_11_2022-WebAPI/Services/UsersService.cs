using _3_11_2022_WebAPI.Entities;
using Newtonsoft.Json;

namespace _3_11_2022_WebAPI.Services
{
    public class UsersService
    {
        private readonly DataService _dataService;
        public List<UserEntity> UsersStore;

        public UsersService(DataService dataService)
        {
            _dataService = dataService;

            if (!File.Exists(_dataService.GetFileName()))
                UsersStore = new List<UserEntity>();
            else
            {
                var jsonText = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), _dataService.GetFileName()));

                UsersStore = JsonConvert.DeserializeObject<List<UserEntity>>(jsonText) ?? new List<UserEntity>();
            }
        }
    }
}
