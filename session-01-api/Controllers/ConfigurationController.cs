using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace session01api.Controllers
{
    [Route("api/[controller]")]
    public class ConfigurationController : Controller
    {
        public IConfiguration Configuration { get; }
        public ConfigurationController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            return Configuration["MyCustomKey"];
        }
    }
}
