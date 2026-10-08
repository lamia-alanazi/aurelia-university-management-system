using System.Linq;
using System.Web.Mvc;
using lamia12771.Models;

namespace lamia12771.Controllers
{
    public class AdminController : Controller
    {
        private readonly SchoolContext db = new SchoolContext();

        // Check if an admin session already exists
        private bool IsAdminLoggedIn()
        {
            return Session["IsAdmin"] != null
                && Session["IsAdmin"] is bool
                && (bool)Session["IsAdmin"];
        }

        // Display admin login page
        [HttpGet]
        public ActionResult Login()
        {
            // Redirect logged-in admins to the home page.
            if (IsAdminLoggedIn())
            {
                return RedirectToAction(
                    "Index",
                    "Home"
                );
            }

            return View(
                new AdminLoginViewModel()
            );
        }

        // Handle admin login request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string username =
                model.Username.Trim();

            // Find the admin account in the database.
            Admin admin =
                db.Admins.FirstOrDefault(
                    a => a.Username == username
                );

            if (admin == null)
            {
                ModelState.AddModelError(
                    "",
                    "Invalid username or password."
                );

                return View(model);
            }

            bool passwordIsCorrect =
                PasswordHasher.VerifyPassword(
                    model.Password,
                    admin.PasswordHash,
                    admin.PasswordSalt
                );

            if (!passwordIsCorrect)
            {
                // Keep the same message for invalid username or password.
                ModelState.AddModelError(
                    "",
                    "Invalid username or password."
                );

                return View(model);
            }

            // Create admin session after successful login
            Session.Clear();

            Session["IsAdmin"] = true;

            Session["AdminUsername"] =
                admin.Username;

            return RedirectToAction(
                "Index",
                "Home"
            );
        }

        // Logout current admin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            Session.Clear();

            Session.Abandon();

            return RedirectToAction(
                "Index",
                "Home"
            );
        }

        // Release database resources
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}