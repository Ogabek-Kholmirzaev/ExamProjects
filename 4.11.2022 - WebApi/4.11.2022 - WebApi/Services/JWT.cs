using Microsoft.Extensions.Options;

namespace _4._11._2022___WebApi.Entities
{
    public class Jwt
    {
        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}
