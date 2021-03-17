using System.Threading.Tasks;
using System.Web.Http;
using WebUserManagement.Api.DTO;
using WebUserManagement.Api.Services;

namespace WebUserManagement.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] CreateUserRequest request)
        {
            return Ok(await _service.CreateAsync(request));
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(long id, [FromBody] UpdateUserRequest request)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(long id)
        {
            return Ok(await _service.DeleteAsync(id));
        }
    }
}