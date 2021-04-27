using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeloAPP.Models;

namespace VeloAPP.Controllers
{
    public class KolesoController : ControllerBase
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(KolesoController));
        private readonly BicycleAppDBContext context;

        public KolesoController(BicycleAppDBContext context)
        {
            this.context = context;

        }
        //public ActionResult Index(int page = 1)
        //{
        //    int pageSize = 3;
        //    IEnumerable<Detail> detailsPerPages = details.Skip((page - 1) * pageSize).Take(pageSize);
        //    PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = details.Count };
        //    IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Details = detailsPerPages };
        //    return View(ivm);
        //}

        [HttpGet]
        public IEnumerable<Koleso> Get()
        {
            // Index(1);
            Log.Info("Get method in Koleso was invoked");
            return context.Kolesos;
        }

        [HttpGet("{id}")]
        public Koleso Get(int id)
        {
            Log.Info("Get method with id in Koleso was invoked");
            return context.Kolesos.FirstOrDefault(x => x.KolesoId == id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Koleso data)
        {
            Log.Info("Post method in Koleso was invoked");
            try
            {
                context.Kolesos.Add(data);
                context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Koleso entity)
        {
            Log.Info("Put method in Koleso was invoked");
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public IActionResult Delete(Koleso entity)
        {
            Log.Info("Delete method in Koleso was invoked");
            try
            {
                context.Kolesos.Remove(entity);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
