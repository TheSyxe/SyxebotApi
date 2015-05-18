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
    public class ChattersController : ApiController
    {
        private SyxebotDatabaseModel db = new SyxebotDatabaseModel();

        

        // GET: api/Chatters/<channelName>
        [ResponseType(typeof(List<Chatter>))]
        public async Task<IHttpActionResult> GetChatters(string channelName)
        {
            Channel channel = await db.Channels.FirstAsync(c => c.Name.ToLower() == channelName.ToLower());
            if (channel == null)
            {
                return NotFound();
            }
            List<Chatter> chatters = new List<Chatter>();
            chatters = channel.Chatters.ToList();
            return Ok(chatters);
        }
        // GET: api/Chatters/<channelName>/<chatterName>
        [ResponseType(typeof(Chatter))]
        public async Task<IHttpActionResult> GetChatter(string channelName, string chatterName)
        {
            Channel channel = await db.Channels.FirstAsync(c => c.Name.ToLower() == channelName.ToLower());
            if (channel == null)
                return NotFound();
            Chatter chatter = channel.Chatters.First(v => v.Name.ToLower() == chatterName.ToLower());
            if (chatter == null)
                return NotFound();
            return Ok(chatter);
        }
        //// PUT: api/Chatters/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutChatter(int id, Chatter chatter)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != chatter.ChatterId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(chatter).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ChatterExists(id))
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

        //// POST: api/Chatters
        //[ResponseType(typeof(Chatter))]
        //public async Task<IHttpActionResult> PostChatter(Chatter chatter)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Chatters.Add(chatter);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = chatter.ChatterId }, chatter);
        //}

        //// DELETE: api/Chatters/5
        //[ResponseType(typeof(Chatter))]
        //public async Task<IHttpActionResult> DeleteChatter(int id)
        //{
        //    Chatter chatter = await db.Chatters.FindAsync(id);
        //    if (chatter == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Chatters.Remove(chatter);
        //    await db.SaveChangesAsync();

        //    return Ok(chatter);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatterExists(int id)
        {
            return db.Chatters.Count(e => e.ChatterId == id) > 0;
        }
    }
}