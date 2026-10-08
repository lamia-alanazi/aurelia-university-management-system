using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using lamia12771.Models;
using lamia12771.Filters;

namespace lamia12771.Controllers
{
    public class RoomsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // Display rooms list
        public ActionResult Index()
        {
            return View(db.Rooms.ToList());
        }

        // Show room details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest
                );
            }

            Room room = db.Rooms.Find(id);

            if (room == null)
            {
                return HttpNotFound();
            }

            return View(room);
        }

        // Add a new room
        [AdminOnly]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult Create(
            [Bind(Include =
                "RoomId,RoomNumber,RoomName,RoomType,Capacity,Area,Status,Description,Facilities,ImagePath")]
            Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(room);
        }

        // Edit room information
        [AdminOnly]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest
                );
            }

            Room room = db.Rooms.Find(id);

            if (room == null)
            {
                return HttpNotFound();
            }

            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult Edit(
            [Bind(Include =
                "RoomId,RoomNumber,RoomName,RoomType,Capacity,Area,Status,Description,Facilities,ImagePath")]
            Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State =
                    EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // Return to rooms list if validation fails
            return RedirectToAction("Index");
        }

        // Delete room record
        [AdminOnly]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest
                );
            }

            Room room = db.Rooms.Find(id);

            if (room == null)
            {
                return HttpNotFound();
            }

            return View(room);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);

            if (room != null)
            {
                db.Rooms.Remove(room);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // Release database resources
        protected override void Dispose(
            bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}