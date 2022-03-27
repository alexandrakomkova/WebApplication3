using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DictController : Controller
    {
        PhoneRepository phoneRepository = new PhoneRepository();
        PhoneDbContext db = new PhoneDbContext();
        // GET: Dict
        public ActionResult Index()
        {
            return View(db.phones);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(Phone phone)
        {
            /*phoneRepository.Add(phone);
            return RedirectToAction("Index");*/

            db.phones.Add(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            /*var phone = phoneRepository.Get(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);*/

            //var phone = db.phones.Find(id);
            var phone = db.phones.FirstOrDefault(p => p.Id == id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
            /*var phone = db.phones.FirstOrDefault(p => p.Id == id);
            if (phone == null)
                return null;
            else
            {
                phone.lastname = lastname;
                phone.phoneNumber = num;
                db.Entry(phone).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return View(phone);*/
        }


        [HttpPost]
        public ActionResult Update(Phone phoneReq)
        {

            //phoneRepository.Update(phone);
            //return RedirectToAction("Index");

            
            int ID = Int32.Parse(phoneReq.Id.ToString());

            Phone phone = db.phones.FirstOrDefault(p => p.Id == ID);
            if (phone == null)
                return null;
            phone.lastname = phoneReq.lastname.ToString();
            phone.phoneNumber = phoneReq.phoneNumber.ToString();
            db.Entry(phone).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            //var phone = phoneRepository.Get(id);
            //if (phone == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(phone);

            /*if (id != null)
            {
                Phone phone = db.phones.FirstOrDefault(p => p.Id == id);
                if (phone != null)
                {
                    db.phones.Remove(phone);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();*/
            var phone = db.phones.FirstOrDefault(p => p.Id == id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteSave(int? id)
        {
            //phoneRepository.Remove(phoneRepository.Get(id));
            //return RedirectToAction("Index");
            int ID = Int32.Parse(id.ToString());
            if (id != null)
            {
                Phone phone = db.phones.FirstOrDefault(p => p.Id == ID);
                if (phone != null)
                {
                    db.phones.Remove(phone);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}