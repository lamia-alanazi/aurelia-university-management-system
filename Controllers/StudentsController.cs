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

        // Display students list
        [AdminOnly]
        public ActionResult Index()
        {
            // Load teachers for student information
            ViewBag.Teachers =
                db.Teachers
                  .OrderBy(t => t.Name)
                  .ToList();

            // Include teacher details with each student
            var students =
                db.Students
                  .Include(s => s.Teacher)
                  .OrderBy(s => s.Name)
                  .ToList();

            return View(students);
        }

        // Show student details
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

        // Add a new student
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

        // Edit student information
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

        // Delete student record
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