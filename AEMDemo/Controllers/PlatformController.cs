using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using AEMDemo.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AEMDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly AEMDemoContext _context;

        public PlatformController(AEMDemoContext context)
        {
            _context = context;
        }

        static HttpClient client = new HttpClient();


        // GET: api/<PlatformController>
        [HttpGet]
        public async Task<IEnumerable<PlatformDto>> Get()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Key.authKey) ;

            HttpResponseMessage response = await client.GetAsync(
            "http://test-demo.aemenersol.com/api/PlatformWell/GetPlatformWellActual");

            if (response.IsSuccessStatusCode)
            {
                var platforms = response.Content.ReadFromJsonAsync<IEnumerable<PlatformDto>>().Result;

                foreach (var data in platforms)
                {
                    var existData = _context.PlatformDto.SingleOrDefault(a => a.id == data.id);
                    if (existData != null)
                    {
                        _context.Entry(existData).State = EntityState.Detached;
                        _context.Entry(data).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.PlatformDto.Add(data);
                    }
                }
                await _context.SaveChangesAsync();

                return platforms;
            }
            else
            {
                IEnumerable<PlatformDto> empty = Enumerable.Empty<PlatformDto>();
                return empty;
            }
        }
    }
}
