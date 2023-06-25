using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PassionProjectfinalIteration.Controllers
{
    public class BassGuitarController : Controller
    {
        // GET: BassGuitar
        public ActionResult List()
        {

            //communicate with bassguitar data api to retrieve list of animal 
            // curl https://localhost:44332/
            HttpClient client = new HttpClient() { };

            string url = "https://localhost:44332/api/BassGuitarData/ListGuitars";
            HttpResponseMessage response = client.GetAsync(url).Result;
            Debug.WriteLine("The response code is: ");
            Debug.WriteLine(response.StatusCode);
            return View();
        }

        // GET: BassGuitar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BassGuitar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BassGuitar/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BassGuitar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BassGuitar/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BassGuitar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BassGuitar/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
