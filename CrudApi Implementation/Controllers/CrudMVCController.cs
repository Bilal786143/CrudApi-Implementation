using CrudApi_Implementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CrudApi_Implementation.Controllers
{
    public class CrudMVCController : Controller
    {
        ELEARNINGEntities db = new ELEARNINGEntities();
        HttpClient client = new HttpClient();
        // GET: CrudMVC
        public ActionResult Index()
        {
            List<Student> std = new List<Student>();
            client.BaseAddress = new Uri("https://localhost:44389/api/");
            var response = client.GetAsync("CrudApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode) {
                var display = test.Content.ReadAsAsync<List<Student>>();
                std = display.Result;
            }

            return View(std);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {

            client.BaseAddress = new Uri("https://localhost:44389/api/");
            var response = client.PostAsJsonAsync<Student>("CrudApi", s);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View("Edit");
        }



        [HttpGet]
        public ActionResult Details(int id)
        {
            Student std = null;
            client.BaseAddress = new Uri("https://localhost:44389/api/");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student>();
                std = display.Result;
            }

            return View(std);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student std = null;
            client.BaseAddress = new Uri("https://localhost:44389/api/");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student>();
                std = display.Result;
            }

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {

            client.BaseAddress = new Uri("https://localhost:44389/api/");
            var response = client.PutAsJsonAsync<Student>("CrudApi", s);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View("Edit");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            Student std = null;
            client.BaseAddress = new Uri("https://localhost:44389/api/");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student>();
                std = display.Result;
            }

            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteStd(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44389/api/");
            var response = client.DeleteAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Delete");
        }

        //public ActionResult newindex() { 
        //client
        
        //}


    }
}