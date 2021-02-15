using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ZooBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator =>
            _mediator ??= (IMediator) HttpContext.RequestServices.GetService(typeof(IMediator));
    }
}