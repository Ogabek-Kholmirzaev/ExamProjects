using _3_11_2022_WebAPI.Options;
using Microsoft.Extensions.Options;

namespace _3_11_2022_WebAPI.Services
{
    public class DataService
    {
        private readonly DataOptions _options;

        public DataService(IOptions<DataOptions> dataOptions)
        {
            _options = dataOptions.Value;
        }

        public string GetFileName() => _options.FileName;
    }
}
