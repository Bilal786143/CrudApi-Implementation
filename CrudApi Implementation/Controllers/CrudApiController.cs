using CrudApi_Implementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace CrudApi_Implementation.Controllers
{
    public class CrudApiController : ApiController
    {
        ELEARNINGEntities db = new ELEARNINGEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult index() 
        {
            List<Student> list = db.Students.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Create(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();

            return Ok();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetStdById(int id)
        {
            var list = db.Students.Where(x=>x.Student_id==id).FirstOrDefault();
            return Ok(list);
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult Edit(Student s)
        {
            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();

            //Student list = db.Students.Where(x => x.Student_id == s.Student_id).FirstOrDefault();
            //if (list != null)
            //{
            //    list.Student_id = s.Student_id;
            //    list.student_name = s.student_name;
            //    list.student_password = s.student_password;
            //    list.student_pic = s.student_pic;
            //    list.total_enrolment = s.total_enrolment;
            //    db.SaveChanges();
                
            //}
            //else 
            //{
            //    return NotFound();
            //}
            //return Ok(list);
        }



        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var stddel = db.Students.Where(x => x.Student_id == id).FirstOrDefault();
            db.Entry(stddel).State = EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }





    }
}
