using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using lamia12771.Models;
using lamia12771.Filters;

namespace lamia12771.Controllers
{
    public class CoursesController : Controller
    {
        private SchoolContext db = new SchoolContext();


        // =========================================================
        // INDEX
        // =========================================================

        public ActionResult Index()
        {
            // قائمة الدكاترة لاستخدامها في Add / Edit Course
            ViewBag.Teachers =
                db.Teachers
                  .OrderBy(t => t.Name)
                  .ToList();


            // Include Teacher حتى نقدر نعرض اسم الدكتور المرتبط بالكورس
            var courses =
                db.Courses
                  .Include(c => c.Teacher)
                  .ToList();


            return View(courses);
        }


        // =========================================================
        // DETAILS
        // =========================================================

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest
                );
            }


            Course course =
                db.Courses
                  .Include(c => c.Teacher)
                  .FirstOrDefault(c => c.CourseId == id.Value);


            if (course == null)
            {
                return HttpNotFound();
            }


            return View(course);
        }


        // =========================================================
        // CREATE
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
                "CourseId,CourseName,CourseCode,Category,CreditHours," +
                "Schedule,Location,Description,Topics,ImagePath," +
                "Instructor,TeacherId")]
            Course course
        )
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);

                db.SaveChanges();


                return RedirectToAction("Index");
            }


            ViewBag.TeacherId =
                new SelectList(
                    db.Teachers.OrderBy(t => t.Name),
                    "TeacherId",
                    "Name",
                    course.TeacherId
                );


            return View(course);
        }


        // =========================================================
        // EDIT
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


            Course course =
                db.Courses.Find(id);


            if (course == null)
            {
                return HttpNotFound();
            }


            ViewBag.TeacherId =
                new SelectList(
                    db.Teachers.OrderBy(t => t.Name),
                    "TeacherId",
                    "Name",
                    course.TeacherId
                );


            return View(course);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult Edit(
            [Bind(Include =
                "CourseId,CourseName,CourseCode,Category,CreditHours," +
                "Schedule,Location,Description,Topics,ImagePath," +
                "Instructor,TeacherId")]
            Course course
        )
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State =
                    EntityState.Modified;


                db.SaveChanges();


                return RedirectToAction("Index");
            }


            ViewBag.TeacherId =
                new SelectList(
                    db.Teachers.OrderBy(t => t.Name),
                    "TeacherId",
                    "Name",
                    course.TeacherId
                );


            return View(course);
        }


        // =========================================================
        // DELETE
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


            Course course =
                db.Courses
                  .Include(c => c.Teacher)
                  .FirstOrDefault(c => c.CourseId == id.Value);


            if (course == null)
            {
                return HttpNotFound();
            }


            return View(course);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult DeleteConfirmed(int? CourseId)
        {
            if (CourseId == null)
            {
                return RedirectToAction("Index");
            }


            Course course =
                db.Courses.Find(CourseId.Value);


            if (course == null)
            {
                return HttpNotFound();
            }


            db.Courses.Remove(course);

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