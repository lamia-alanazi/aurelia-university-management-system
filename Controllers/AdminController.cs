using System.Linq;
using System.Web.Mvc;
using lamia12771.Models;

namespace lamia12771.Controllers
{
    public class AdminController : Controller
    {
        private readonly SchoolContext db = new SchoolContext();


        // =========================================================
        // CHECK ADMIN SESSION
        // =========================================================

        private bool IsAdminLoggedIn()
        {
            return Session["IsAdmin"] != null
                && Session["IsAdmin"] is bool
                && (bool)Session["IsAdmin"];
        }


        // =========================================================
        // LOGIN - GET
        // =========================================================

        [HttpGet]
        public ActionResult Login()
        {
            /*
             * إذا الأدمن مسجل دخول بالفعل
             * نرجعه للصفحة الرئيسية.
             */

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


        // =========================================================
        // LOGIN - POST
        // =========================================================

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


            /*
             * البحث عن حساب الأدمن الموجود مسبقاً
             * في قاعدة البيانات.
             */

            Admin admin =
                db.Admins.FirstOrDefault(
                    a => a.Username == username
                );


            /*
             * نفس الرسالة سواء كان اسم المستخدم
             * أو كلمة المرور غير صحيحة.
             */

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
                ModelState.AddModelError(
                    "",
                    "Invalid username or password."
                );

                return View(model);
            }


            // =====================================================
            // LOGIN SUCCESS
            // =====================================================

            Session.Clear();

            Session["IsAdmin"] = true;

            Session["AdminUsername"] =
                admin.Username;


            return RedirectToAction(
                "Index",
                "Home"
            );
        }


        // =========================================================
        // LOGOUT
        // =========================================================

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


        // =========================================================
        // DISPOSE
        // =========================================================

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