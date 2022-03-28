using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIWithModel.Models;

namespace APIWithModel.Controllers
{
    public class StudentV2Controller : ApiController
    {
        public HttpResponseMessage Get()
        {
            IPTEntities dbcontext = new IPTEntities();
            var students = dbcontext.Student.ToList();
            var response = Request.CreateResponse<List<Student>>(HttpStatusCode.Accepted, students);
            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            IPTEntities dbcontext = new IPTEntities();
            var student = dbcontext.Student.Where(m => m.StudentId == id).FirstOrDefault();
            if (student != null)
            {
                var response = Request.CreateResponse<Student>(HttpStatusCode.Accepted, student);
                return response;
            }
            else
            {
                var response = Request.CreateResponse(HttpStatusCode.NotFound);
                return response;
            }
        }

        public HttpResponseMessage Post(Student model)
        {
            try
            {
                IPTEntities dbcontext = new IPTEntities();
                Student student = new Student();
                student.Address = model.Address;
                student.Birthday = model.Birthday;
                student.FirstName = model.FirstName;
                student.Gender = model.Gender;
                student.LastName = model.LastName;
                student.MobileNo = model.MobileNo;
                student.StudentId = model.StudentId;
                dbcontext.Student.Add(student);
                dbcontext.SaveChanges();
                var response = Request.CreateResponse<Student>(HttpStatusCode.Created, student);
                return response;
            }
            catch (Exception ex)
            {
                var response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }

        public HttpResponseMessage Put(int id, Student model)
        {
            try
            {
                IPTEntities dbcontext = new IPTEntities();
                var student = dbcontext.Student.Where(m => m.StudentId == id).FirstOrDefault();
                if (student != null)
                {
                    student.Address = model.Address;
                    student.Birthday = model.Birthday;
                    student.FirstName = model.FirstName;
                    student.Gender = model.Gender;
                    student.LastName = model.LastName;
                    student.MobileNo = model.MobileNo;
                    dbcontext.SaveChanges();
                    var response = Request.CreateResponse<Student>(HttpStatusCode.OK, student);
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.NotFound);
                    return response;
                }

            }
            catch (Exception ex)
            {
                var response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                IPTEntities dbcontext = new IPTEntities();
                var student = dbcontext.Student.Where(m => m.StudentId == id).FirstOrDefault();
                if (student != null)
                {
                    dbcontext.Student.Remove(student);
                    dbcontext.SaveChanges();
                    var response = Request.CreateResponse<string>(HttpStatusCode.OK, "Deleted student with ID of " + id);
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.NotFound);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }
    }
}
