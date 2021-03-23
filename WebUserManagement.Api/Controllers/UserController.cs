using System.Threading.Tasks;
using System.Web.Http;
using WebUserManagement.DTO;
using WebUserManagement.Api.Services;
using System.Web.Http.Cors;

namespace WebUserManagement.Api.Controllers
{
    [RoutePrefix("api/users")]
    [EnableCors("*", "*", "*")]
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

        [Route("{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetById(long id)
        {
            return Ok(await _service.GetByIdAsync(id));
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