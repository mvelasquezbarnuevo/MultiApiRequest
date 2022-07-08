using Microsoft.AspNetCore.Mvc;
using WebApiTwo.Messages;


namespace WebApiTwo.Controllers
{
    [Produces("application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ILogger<RequestController> _logger;
       
        public RequestController(ILogger<RequestController> logger)
        {
            _logger = logger;
        }

        [Consumes("application/xml")]
        [HttpPost(Name = "GetOffer")]
        public async Task<IActionResult> GetOffer(XmlRequest request)
        {
            var response = new XmlResponse
            {
                Amount = (decimal?)(request.Packages?[0].Height * request.Packages?[0].Width * 0.85),
            };
            return Ok(response);
        }

    }
}
