using AutoMapper;
using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Enterprise_Web.Controllers.Api
{
    public class StudentsController : ApiController
    {
        private WebEnterpriseEntities _db;
        public StudentsController()
        {
            _db = new WebEnterpriseEntities();
        }
        //GET /api/Student
        public IEnumerable<StudentDto> GetStudent()
        {
            return _db.User_Student_Detail.ToList().Select(Mapper.Map<User_Student_DetailController, StudentDto>);
        }

        //GET /api/Student/1
        public User_Student_Detail GetStudent(int id)
        {
            var student = _db.User_Student_Detail.SingleOrDefault(c => c.stdID == id);

            if (student == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return student;
        }

        //POST /api/Student
        [HttpPost]
        public User_Student_Detail CreateStudent(User_Student_Detail student)
        {
            if (ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _db.User_Student_Detail.Add(student);
            _db.SaveChanges();

            return student;
        }

        //PUT /api/Student/1
        [HttpPut]
        public void UpdateStudent(int id, User_Student_Detail student)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var studentInDb = _db.User_Student_Detail.SingleOrDefault(c => c.stdID == id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            studentInDb.std_fullname = student.std_fullname;
            studentInDb.std_mail = student.std_mail;
            studentInDb.std_gender = student.std_gender;
            studentInDb.std_phone = student.std_phone;
            studentInDb.stdID = student.stdID;
            studentInDb.std_doB = student.std_doB;
            studentInDb.userId = student.userId;

            _db.SaveChanges();
        }

        //Delete /api/Student/1
        [HttpDelete]
        public void DeleteStudent(int id)
        {
            var studentInDb = _db.User_Student_Detail.SingleOrDefault(c => c.stdID == id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _db.User_Student_Detail.Remove(studentInDb);
            _db.SaveChanges();
        }
    }
}
