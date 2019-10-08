using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace session02api.Controllers
{
    [Route("api/[controller]")]
    public class ConfigurationController : Controller
    {
        public IConfiguration Configuration { get; }
        public ConfigurationController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        [HttpGet]
        public IConfiguration Get()
        {
            return Configuration;
        }

        [HttpGet("{key}")]
        public string Get(string key)
        {
            return Configuration[key];
        }
    }
}
