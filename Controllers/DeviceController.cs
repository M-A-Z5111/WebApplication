using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.DataBase;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DeviceController : Controller
    {
        WebAppDbContext mydb = new WebAppDbContext();
        public ActionResult Index()
        {
            List<Device> devicelist = new List<Device>();
            devicelist = (from obj in mydb.Devices select obj).ToList() ;
            return View(devicelist);
        }
        public ActionResult Details(int id)
        {
            Device device = new Device();

            device = (from obj in mydb.Devices where obj.DeviceId== id select obj).FirstOrDefault();

            return View("Details",device);
        
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            return View("Create");

        }
        [HttpPost]
        public ActionResult Create(Device device)
        {
            mydb.Devices.Add(device);
            mydb.SaveChanges();

            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id )
        {
            Device device = new Device();
            device = (from obj in mydb.Devices where obj.DeviceId == id select obj).FirstOrDefault();
            

            
           return View("Edit",device);
        }
        [HttpPost]
        public ActionResult Edit( Device devicemodel)
        {
            
           Device device= mydb.Devices.SingleOrDefault(d => d.DeviceId == devicemodel.DeviceId);
            
               device.DeviceName = devicemodel.DeviceName;
                mydb.SaveChanges();

                return RedirectToAction("Index");
           
          

        }

        public ActionResult Delete(int id) 
        {
            Device device = new Device();
            device = (from obj in mydb.Devices where obj.DeviceId==id select obj).FirstOrDefault();
            mydb.Devices.Remove(device);
            mydb.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}