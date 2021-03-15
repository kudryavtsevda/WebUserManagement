using AutoMapper;
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
        public async Task<IHttpActionResult> Create(CreateUserRequest request)
        {
            return Ok(await _service.CreateAsync(request));
        }
    }
}