using AutoMapper;
using Enterprise_Web.Dtos;
using Enterprise_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public IEnumerable<StudentDto> GetStudents()
        {
            return _db.User_Student_Detail.ToList().Select(extractedStudent => Mapper.Map<User_Student_Detail, StudentDto>(extractedStudent));
        }

        //GET /api/Student/1
        public StudentDto GetStudent(int id)
        {
            var student = _db.User_Student_Detail.SingleOrDefault(c => c.stdID == id);

            if (student == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<User_Student_Detail, StudentDto>(student);
        }

        //POST /api/Student
        [HttpPost]
        public StudentDto CreateStudent(StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var student = Mapper.Map<StudentDto, User_Student_Detail>(studentDto);
            _db.User_Student_Detail.Add(student
                );
            _db.SaveChanges();

            studentDto.stdID = student.stdID;

            return studentDto;
        }

        //PUT /api/Student/1
        [HttpPut]
        public void UpdateStudent(int id, StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var studentInDb = _db.User_Student_Detail.SingleOrDefault(c => c.stdID == id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(studentDto, studentInDb);

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
