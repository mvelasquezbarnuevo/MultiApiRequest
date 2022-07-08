using Microsoft.AspNetCore.Mvc;
using WebApiThree.Messages;

namespace WebApiThree.Controllers
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
                Amount = (decimal?)(request.Cartons?[0].Height * request.Cartons?[0].Width * 0.95),
            };

            return Ok(response);
        }
    }

    
}
