using Microsoft.AspNetCore.Mvc;

namespace _3_11_2022_WebAPI.Filters
{
    public class RoleAttribute : TypeFilterAttribute
    {
        public RoleAttribute(string role) : base(typeof(AuthAttribute))
        {
            Arguments = new object[] { role };
        }
    }
}
