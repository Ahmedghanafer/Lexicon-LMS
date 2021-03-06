﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lexicon_LMS.Models;
using Microsoft.AspNet.Identity;

namespace Lexicon_LMS.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses

        [Authorize(Roles = "Teacher,Student")]
        public ActionResult Index(ApplicationUser user)
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.Single(m => m.Id == currentUserId);
          
           
            if (User.IsInRole("Student"))
            {
                var course = db.Courses.Where(m => m.Id == currentUser.CourseId);
                return View(course.ToList());
            }
            else
                return View(db.Courses.ToList());

        }
        // GET: Courses/Details/5
        [Authorize(Roles = "Teacher,Student")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course course = db.Courses.Find(id);

            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }



        [Authorize(Roles = "Teacher,Student")]
        public ActionResult CourseModule(int? id)
        {
            var module = db.Modules.Where(m => m.CourseId == id);

            
            return View(module);
        }

        public ActionResult CourseStudents(int? id)
        {
            List<CourseStudents> studentsList = new List<CourseStudents>();
          
            foreach (var student in db.Users.Where(m => m.CourseId == id).ToList())
            {
                studentsList.Add(new Models.CourseStudents
                {
                    Id = student.Id,
                    Email = student.Email
                });
            }
            return View(studentsList);
        }


        // GET: Courses/Create
        [Authorize(Roles = "Teacher")]
        public ActionResult Create()
        {
            return View();
        }


        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTime,EndTime,Name,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }


        // GET: Courses/Edit/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,EndTime,Name,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }


        // GET: Courses/Delete/5
        //[Authorize(Roles = "Teacher")]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Course course = db.Courses.Find(id);
        //    if (course == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(course);
        //}

        // POST: Courses/Delete/5
        //[Authorize(Roles ="Teacher")]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Course course = db.Courses.Find(id);
        //    db.Courses.Remove(course);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
