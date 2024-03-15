using AEMDemo.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AEMDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformDummyController : ControllerBase
    {
        private readonly AEMDemoContext _context;

        public PlatformDummyController(AEMDemoContext context)
        {
            _context = context;
        }

        static HttpClient client = new HttpClient();

        // GET: api/<PlatformDummyController>
        [HttpGet]
        public async Task<IEnumerable<PlatformDummyDto>> Get()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Key.authKey);

            HttpResponseMessage response = await client.GetAsync(
            "http://test-demo.aemenersol.com/api/PlatformWell/GetPlatformWellDummy");

            if (response.IsSuccessStatusCode)
            {
                var platforms = response.Content.ReadFromJsonAsync<IEnumerable<PlatformDummyDto>>().Result;

                return platforms;
            }
            else
            {
                IEnumerable<PlatformDummyDto> empty = Enumerable.Empty<PlatformDummyDto>();
                return empty;
            }
        }
        
    }
}
