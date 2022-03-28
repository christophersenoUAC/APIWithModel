using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIWithModel.Models;

namespace APIWithModel.Controllers
{
    public class StudentController : ApiController
    {
        //CRUD - Create, Read, Update, Delete against our DB
        public List<Student> Get()
        {
            IPTEntities dbcontext = new IPTEntities();
            var students = dbcontext.Student.ToList();
            return students;
        }
        public Student Get(int id)
        {
            IPTEntities dbcontext = new IPTEntities();
            var student = dbcontext.Student.Where(m=>m.StudentId==id).FirstOrDefault();
            return student;
        }

        public string Post(Student model)
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
            int x = dbcontext.SaveChanges();
            if(x>0)
            {
                return "Data has been added successfully";
            }
            else
            {
                return "Failed to add the new item";
            }
        }

        public string Put(int id, Student model)
        {
            IPTEntities dbcontext = new IPTEntities();
            var student = dbcontext.Student.Where(m => m.StudentId == id).FirstOrDefault();
            student.Address = model.Address;
            student.Birthday = model.Birthday;
            student.FirstName = model.FirstName;
            student.Gender = model.Gender;
            student.LastName = model.LastName;
            student.MobileNo = model.MobileNo;
            int x = dbcontext.SaveChanges();
            if (x > 0)
            {
                return "Data has been updated successfully";
            }
            else
            {
                return "Failed to update the item";
            }
        }
        public string Delete(int id)
        {
            IPTEntities dbcontext = new IPTEntities();
            var student = dbcontext.Student.Where(m => m.StudentId == id).FirstOrDefault();
            dbcontext.Student.Remove(student);
            int x= dbcontext.SaveChanges();
            if (x > 0)
            {
                return "Data has been delete successfully";
            }
            else
            {
                return "Failed to delete the item";
            }
        }
    }
}
