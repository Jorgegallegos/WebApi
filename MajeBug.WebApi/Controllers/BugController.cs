using MajeBud.Data;
using MajeBud.Data.Repositories;
using MajeBug.Domain;
using MajeBug.WebApi.Helpers;
using MajeBug.WebApi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace MajeBug.WebApi.Controllers
{
    [Authorize]
    public class BugController : BaseApi
    {

        //DataContext ctx = new DataContext();

        //protected override void Dispose(bool disposing)
        //{
        //    ctx.Dispose();
        //    base.Dispose(disposing);
        //}

        [ResponseType(typeof(List<BugApi>))]
        // GET: api/Bug
        public IHttpActionResult Get()
        {
            using (var ctx = new DataContext())
            {
                BugRepository bugRepository = new BugRepository(ctx);
                var bugs = bugRepository.GetAll();
                var models = MapperHelper.Map<ICollection<BugApi>>(bugs);
                return Ok(models);
            }
        }


        [ResponseType(typeof(BugApi))]
        // GET: api/Bug/5
        public IHttpActionResult Get(int id)
        {
            using (var ctx = new DataContext())
            {
                BugRepository bugRepository = new BugRepository(ctx);
                var bug = bugRepository.Find(id);
                UserRepository userRepository = new UserRepository(ctx);
                bug.CreatedBy = userRepository.Find(bug.CreatedById);
                if (bug.ModfiedById != null)
                {
                    bug.ModifiedBy = userRepository.Find(bug.ModfiedById);
                }

                var model = MapperHelper.Map<BugApi>(bug);
                return Ok(model);
            }
        }

        [ResponseType(typeof(BugApi))]
        // POST: api/Bug
        public IHttpActionResult Post([FromBody]CreateBugApi model)
        {
            if (!ModelState.IsValid)
                  return BadRequest(ModelState);

            using (var ctx=new DataContext())
            {
                BugRepository bugRepository = new BugRepository(ctx);
                var bug = MapperHelper.Map<Bug>(model);
                bug.CreatedAt = DateTime.Now;
                bug.CreatedById = CurrentUserId;
                bugRepository.Insert(bug);
                ctx.SaveChanges();
                var bugApi = MapperHelper.Map<BugApi>(bug);
                return Ok(bugApi);
            }
        }

        // PUT: api/Bug/5
        public IHttpActionResult Put(int id, [FromBody]BugApi model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                using (var ctx = new DataContext())
                {
                    BugRepository bugRepository = new BugRepository(ctx);
                    var bug = MapperHelper.Map<Bug>(model);
                    bug.ModifiedAt = DateTime.Now;

                    bug.ModfiedById = User.Identity.GetUserId();

                    bug.ModfiedById = CurrentUserId;
                    bugRepository.Update(bug);
                    ctx.SaveChanges();
                    var bugApi = MapperHelper.Map<BugApi>(bug);
                    return Ok(bugApi);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Conflict, new { Message = "El registro ha sido modificado" }));

            }
        }

        // DELETE: api/Bug/5
        public void Delete(int id)
        {
        }
    }
}
