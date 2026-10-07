using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using lamia12771.Models;
using lamia12771.Filters;

namespace lamia12771.Controllers
{
    public class StudentsController : Controller
    {
        private SchoolContext db = new SchoolContext();


        // =========================================================
        // INDEX
        // ADMIN ONLY
        // =========================================================

        [AdminOnly]
        public ActionResult Index()
        {
            ViewBag.Teachers =
                db.Teachers
                  .OrderBy(t => t.Name)
                  .ToList();

            var students =
                db.Students
                  .Include(s => s.Teacher)
                  .OrderBy(s => s.Name)
                  .ToList();

            return View(students);
        }


        // =========================================================
        // DETAILS
        // ADMIN ONLY
        // =========================================================

        [AdminOnly]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest
                );
            }

            Student student =
                db.Students
                  .Include(s => s.Teacher)
                  .FirstOrDefault(
                      s => s.StudentId == id.Value
                  );

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }


        // =========================================================
        // CREATE
        // ADMIN ONLY
        // =========================================================

        [AdminOnly]
        public ActionResult Create()
        {
            ViewBag.TeacherId =
                new SelectList(
                    db.Teachers.OrderBy(t => t.Name),
                    "TeacherId",
                    "Name"
                );

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult Create(
            [Bind(Include =
                "StudentId,Name,Age,Major,Level,GPA,CreditsCompleted," +
                "DegreeProgress,AcademicStanding,Email,ImagePath,TeacherId")]
            Student student
        )
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Teachers =
                db.Teachers
                  .OrderBy(t => t.Name)
                  .ToList();

            return View(
                "Index",
                db.Students
                  .Include(s => s.Teacher)
                  .OrderBy(s => s.Name)
                  .ToList()
            );
        }


        // =========================================================
        // EDIT
        // ADMIN ONLY
        // =========================================================

        [AdminOnly]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest
                );
            }

            Student student =
                db.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            ViewBag.TeacherId =
                new SelectList(
                    db.Teachers.OrderBy(t => t.Name),
                    "TeacherId",
                    "Name",
                    student.TeacherId
                );

            return View(student);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult Edit(
            [Bind(Include =
                "StudentId,Name,Age,Major,Level,GPA,CreditsCompleted," +
                "DegreeProgress,AcademicStanding,Email,ImagePath,TeacherId")]
            Student student
        )
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State =
                    EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Teachers =
                db.Teachers
                  .OrderBy(t => t.Name)
                  .ToList();

            return View(
                "Index",
                db.Students
                  .Include(s => s.Teacher)
                  .OrderBy(s => s.Name)
                  .ToList()
            );
        }


        // =========================================================
        // DELETE
        // ADMIN ONLY
        // =========================================================

        [AdminOnly]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest
                );
            }

            Student student =
                db.Students
                  .Include(s => s.Teacher)
                  .FirstOrDefault(
                      s => s.StudentId == id.Value
                  );

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student =
                db.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            db.Students.Remove(student);

            db.SaveChanges();

            return RedirectToAction("Index");
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