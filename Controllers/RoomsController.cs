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

        // GET: Rooms
        public ActionResult Index()
        {
            return View(db.Rooms.ToList());
        }

        // GET: Rooms/Details/5
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

        // GET: Rooms/Create
        [AdminOnly]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
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

        // GET: Rooms/Edit/5
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

        // POST: Rooms/Edit/5
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

            // حتى لو صار Validation Error
            // نرجع إلى Rooms بدل صفحة Edit القديمة
            return RedirectToAction("Index");
        }

        // GET: Rooms/Delete/5
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

        // POST: Rooms/Delete/5
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