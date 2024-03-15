using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AEMDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        static HttpClient client = new HttpClient();

        // POST api/<LoginController>
        [HttpPost]
        public async Task<string> Post([FromBody] LoginRequest login)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
            "http://test-demo.aemenersol.com/api/Account/Login", login);

            if (response.IsSuccessStatusCode)
            {
                Key.authKey = await response.Content.ReadFromJsonAsync<string>();
            }

            return "Logged in with key : " + Key.authKey;

        }
    }
}
