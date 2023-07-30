using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.DataBase;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PhoneNumberController : Controller
    {
        WebAppDbContext mydb = new WebAppDbContext();
        public ActionResult Index()
        {
            List<PhoneNumber> phonelist = new List<PhoneNumber>();
            phonelist = (from obj in mydb.PhoneNumbers select obj).ToList();
            return View("Index"); ;
     
        }
        public ActionResult Details(int id)
        {
            PhoneNumber phonenumber = new PhoneNumber();

            phonenumber = (from obj in mydb.PhoneNumbers where obj.PhoneId == id select obj).FirstOrDefault();

            return View("Details");

        }
        public ActionResult Create(PhoneNumber   phonenumber)
        {

            mydb.PhoneNumbers.Add(phonenumber);
            mydb.SaveChanges();
            return View("Index");

        }
        public ActionResult Edit(int id, PhoneNumber newclient)
        {
            PhoneNumber phonenumber = new PhoneNumber();
            phonenumber = (from obj in mydb.PhoneNumbers where obj.PhoneId == id select obj).FirstOrDefault();
            phonenumber.Number = newclient.Number;

            mydb.PhoneNumbers.AddOrUpdate(phonenumber);
            mydb.SaveChanges();
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            PhoneNumber phonenumber = new PhoneNumber();
            phonenumber = (from obj in mydb.PhoneNumbers where obj.PhoneId == id select obj).FirstOrDefault();
            mydb.PhoneNumbers.Remove(phonenumber);
            mydb.SaveChanges();
            return View("Index");
        }

    }
}