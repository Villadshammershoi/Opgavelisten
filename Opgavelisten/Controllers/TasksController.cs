using Opgavelisten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Opgavelisten.Controllers
{
    public class TasksController : ApiController
    {

        //LISTIFY SOME SHIT
        private DataContext _db = new DataContext();
        [HttpGet]
        public List<Task> TaskList()
        {
            return _db.Tasks.OrderBy(p => p.Id).ToList();
        }

        //FETCH SOME SHIT
        [HttpGet]
        public IHttpActionResult GetTaskById(int id)
        {
            Task tasks = _db.Tasks.Where(p => p.Id == id).FirstOrDefault();
            if (tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        //CREAT SOME SHIT
        [HttpPost]
        public IHttpActionResult CreateTask(Task model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Tasks.Add(model);
            _db.SaveChanges();

            return Ok(model);
        }

        [HttpPut]
        public IHttpActionResult EditTask(Task model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return Ok(model);
        }


        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            Task tasks = _db.Tasks.Where(p => p.Id == id).FirstOrDefault();
            if (tasks == null)
            {
                return NotFound();
            }

            _db.Tasks.Remove(tasks);
            _db.SaveChanges();

            return Ok(tasks);
        }            
    }
}
