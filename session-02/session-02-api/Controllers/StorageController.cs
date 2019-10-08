using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using session_02_api.Storage.Context;
using session_02_api.Storage.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace session02api.Controllers
{
    [Route("api/[controller]")]
    public class StorageController : Controller
    {
        public IConfiguration Configuration { get; }
        public CloudStorage CloudStorage { get; }

        public StorageController(IConfiguration configuration)
        {
            Configuration = configuration;
            CloudStorage = new CloudStorage(Configuration["ConnectionStrings:StorageConnectionString"]);
        }

        // GET: api/values
        [HttpGet("{container}")]
        public IEnumerable<StorageItem> Get(string container)
        {
            return CloudStorage.GetContainerItems(container);
        }
    }
}
