using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SyxebotApi.Models;

namespace SyxebotApi.Controllers
{
    public class BotsController : ApiController
    {
        private SyxebotDatabaseModel db = new SyxebotDatabaseModel();

        // GET: api/Bots
        //public IQueryable<Bot> GetBots()
        //{
        //    return db.Bots;
        //}

        // GET: api/Bots/5
        //TODO: AuthorizedCall
        [ResponseType(typeof(Bot))]
        public async Task<IHttpActionResult> GetBot(int id)
        {
            Bot bot = await db.Bots.FindAsync(id);
            if (bot == null)
            {
                return NotFound();
            }

            return Ok(bot);
        }
        // GET: api/Bots/<botName>
        //TODO: AuthorizedCall
        [ResponseType(typeof(Bot))]
        public async Task<IHttpActionResult> GetBot(string botName)
        {
            Bot bot = await db.Bots.FirstAsync(c => c.Name.ToLower() == botName.ToLower());
            if (bot == null)
            {
                return NotFound();
            }

            return Ok(bot);
        }

        // PUT: api/Bots/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutBot(int id, Bot bot)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != bot.BotId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(bot).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BotExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Bots
        //[ResponseType(typeof(Bot))]
        //public async Task<IHttpActionResult> PostBot(Bot bot)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Bots.Add(bot);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = bot.BotId }, bot);
        //}

        // DELETE: api/Bots/5
        //[ResponseType(typeof(Bot))]
        //public async Task<IHttpActionResult> DeleteBot(int id)
        //{
        //    Bot bot = await db.Bots.FindAsync(id);
        //    if (bot == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Bots.Remove(bot);
        //    await db.SaveChangesAsync();

        //    return Ok(bot);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BotExists(int id)
        {
            return db.Bots.Count(e => e.BotId == id) > 0;
        }
    }
}