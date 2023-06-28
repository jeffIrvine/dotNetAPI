using Microsoft.AspNetCore.Mvc;

namespace dotNetAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        public string Get()
        {
            return "Hello world!";
        }
    }
}