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
        public async Task<ActionResult> List()
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
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserModel request)
        {
            if (!ModelState.IsValid)
                return View(request);

            _ = await _handler.CreateAsync(new CreateUserRequest
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                Email = request.Email
            });

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(long id)
        {
            _ = await _handler.DeleteAsync(id);
            return RedirectToAction("List");
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}