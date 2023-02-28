using Microsoft.AspNetCore.Mvc;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
