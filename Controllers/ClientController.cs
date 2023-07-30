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
    public class ClientController : Controller
    {
        WebAppDbContext mydb = new WebAppDbContext();
        public ActionResult Index()
        {
            List<Client> clientlist = new List<Client>();
            clientlist = (from obj in mydb.Clients select obj).ToList();
            return View(clientlist);
        }
        public ActionResult Details(int id)
        {
            Client client = new Client();

            client = (from obj in mydb.Clients where obj.ClientId == id select obj).FirstOrDefault();

            return View("Details");

        }
        [HttpGet]
        public ActionResult Create()
        {

            return View("Create");

        }
        [HttpPost]
        public ActionResult Create(Client client)
        {
            mydb.Clients.Add(client);
            mydb.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Edit(int id, Client newclient)
        {
            Client client = new Client();
            client = (from obj in mydb.Clients where obj.ClientId == id select obj).FirstOrDefault();
            client.ClientName = newclient.ClientName;

            mydb.Clients.AddOrUpdate(client);
            mydb.SaveChanges();
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            Client client = new Client();
            client = (from obj in mydb.Clients where obj.ClientId == id select obj).FirstOrDefault();
            mydb.Clients.Remove(client);
            mydb.SaveChanges();
            return View("Index");
        }
    }
}