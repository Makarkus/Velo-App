using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeloAPP.Models;

namespace VeloAPP.Controllers
{
    public class RamaController : ControllerBase
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(KolesoController));
        private readonly BicycleAppDBContext context;

        public RamaController(BicycleAppDBContext context)
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
        public IEnumerable<Rama> Get()
        {
            // Index(1);
            Log.Info("Get method in Rama was invoked");
            return context.Ramas;
        }

        [HttpGet("{id}")]
        public Rama Get(int id)
        {
            Log.Info("Get method with id in Rama was invoked");
            return context.Ramas.FirstOrDefault(x => x.RamaId == id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Rama data)
        {
            Log.Info("Post method in Rama was invoked");
            try
            {
                context.Ramas.Add(data);
                context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Rama entity)
        {
            Log.Info("Put method in Rama was invoked");
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
        public IActionResult Delete(Rama entity)
        {
            Log.Info("Delete method in Rama was invoked");
            try
            {
                context.Ramas.Remove(entity);
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
