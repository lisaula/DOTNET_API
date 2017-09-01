using Entity_CodeFirst.models;
using Newtonsoft.Json;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository<Student> studentRepository;
        public StudentController(IRepository<Student> _studentRepository)
        {
            studentRepository = _studentRepository;
        }

        public HttpResponseMessage Post(Student _student)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            studentRepository.InsertEntity(_student);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }

        public HttpResponseMessage GetAll()
        {
            var query = studentRepository.GelAllEntities();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(query.ToList()));
            return response;
        }

        //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
    }
}