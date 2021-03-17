using System.Threading.Tasks;
using System.Web.Mvc;
using WebUserManagement.DTO;
using WebUserManagement.Mvc.UI.Handler;
using WebUserManagement.Mvc.UI.Models;

namespace WebUserManagement.Mvc.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserHandler _handler;
        public UserController()
        {
            _handler = new UserHandler();
        }
        public async Task<ActionResult> Index()
        {
            var res = await _handler.GetAllAsync();
            return View(res);
        }

        [HttpGet]
        public async Task<ActionResult> EditUser(long id)
        {
            var user = await _handler.GetByIdAsync(id);
            var model = new EditUserModel()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(long id, UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
                return View(new EditUserModel()
                {
                    Id = id,
                    LastName = request.LastName,
                    FirstName = request.FirstName,
                    Email = request.Email
                });

            _ = await _handler.UpdateAsync(id, request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            _ = await _handler.CreateAsync(request);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(long id)
        {
            _ = await _handler.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}