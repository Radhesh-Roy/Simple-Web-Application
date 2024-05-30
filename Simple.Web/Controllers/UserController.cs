using Microsoft.AspNetCore.Mvc;
using Simple.Web.Data;
using Simple.Web.Models;

namespace Simple.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult<User> Index()
        {
            var data=_context.Set<User>().ToList();
            return View(data);  
        }

        public IActionResult CreateOrEdit(int id) {
            if (id==0)
            {
                return View(new User());  
                
            }
            else
            {
                return View(_context.Set<User>().Find(id));
            }


        }

        [HttpPost]
        public IActionResult CreateOrEdit(int id, User user) {

            if (id==0)
            {
                _context.Set<User>().Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                _context.Set<User>().Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public IActionResult Delete(int id)
        {
            var data=_context.Set<User>().Find(id);
            if (data != null)
            {
                _context.Set<User>().Remove(data);
                _context.SaveChanges();
                return RedirectToAction("Index");   
            }
            return RedirectToAction("Index");
        }

    }
}
