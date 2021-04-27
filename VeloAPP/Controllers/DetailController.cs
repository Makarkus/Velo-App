using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeloAPP.Models;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace VeloAPP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetailController : ControllerBase
    {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(DetailController));
        private readonly BicycleAppDBContext context;

        public DetailController(BicycleAppDBContext context)
        {
            this.context = context;

        }
        
        [HttpGet]
        public IEnumerable<Detail> Get()
        {
            Log.Info("Get method in Details was invoked");
            /*PAGINATION*/

            //int page = 1;
            //int pageSize = 3;
            //IEnumerable<Detail> detailsPerPages = context.Details.Skip((page - 1) * pageSize).Take(pageSize);
            //PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = context.Details.Count };
            //IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Details = detailsPerPages };
            //return detailsPerPages;
            return context.Details;
        }

        [HttpGet("{id}")]
        public Detail Get(int id)
        {
            Log.Info("Get method with id in Details was invoked");
            return context.Details.FirstOrDefault(x => x.DetailId == id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Detail data)
        {
            Log.Info("Post method in Details was invoked");
            try
            {
                context.Details.Add(data);
                context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Detail entity)
        {
            Log.Info("Put method in Details was invoked");
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
        public IActionResult Delete(Detail entity)
        {
            Log.Info("Delete method in Details was invoked");
            try
            {
                context.Details.Remove(entity);
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
