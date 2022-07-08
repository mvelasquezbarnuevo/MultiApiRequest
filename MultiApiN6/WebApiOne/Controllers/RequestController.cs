using Microsoft.AspNetCore.Mvc;
using WebApiOne.Messages;

namespace WebApiOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ILogger<RequestController> _logger;

        public RequestController(ILogger<RequestController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetOffer")]
        public async Task<IActionResult> GetOffer(RequestMessage request)
        {
            var response = new ResponseMessage
            {
                Total = (decimal?)(request.CartonDimensions?[0].Height * request.CartonDimensions?[0].Width * 0.9),
            };

            return Ok(response);
        }

    }
}
