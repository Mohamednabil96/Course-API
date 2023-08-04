using APITaskDay1.Models;
using Microsoft.AspNetCore.Mvc;

namespace APITaskDay1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        MyDbContext db;
        public CourseController(MyDbContext db)
        {
            this.db = db;
        }

        // 1
        [HttpGet]
        public ActionResult<Course> get()
        {
            var crs = db.Course.ToList();
            if (crs.Any())
            {
                return Ok(crs);
            }
            else return NotFound();
        }

        //2 
        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            Course crs = db.Course.Find(id);
            if (crs == null) return NotFound();
            else
            {
                db.Course.Remove(crs);
                db.SaveChanges();
                return Ok(crs);
            }
        }

        //3
        [HttpPut("{id}")]
        public ActionResult edit(Course crs, int id)
        {
            if (crs == null) return BadRequest();
            if (crs.Id != id) return BadRequest();

            db.Entry(crs).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }


        //4
        [HttpPost]
        public ActionResult post(Course Crs)
        {
            if (Crs == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                db.Course.Add(Crs);
                db.SaveChanges();

                return Created("Created", Crs);
            }


        }


        //5 
        [HttpGet("{id:int}")]
        public ActionResult getbyid(int id)
        {
            Course crs = db.Course.Find(id);
            if (crs == null)
                return NotFound();
            else
                return Ok(crs);
        }


        //6
        [HttpGet("{name:alpha}")]
        public Course getbyname(string name)
        {
            return db.Course.FirstOrDefault(n => n.CrsName == name);
        }


    }
}
