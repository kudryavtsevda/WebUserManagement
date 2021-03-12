using System.Threading.Tasks;
using System.Web.Http;
using WebUserManagement.Api.Services;

namespace WebUserManagement.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserService _service;

        public UserController()
        {
            _service = new UserService();
        }

        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}