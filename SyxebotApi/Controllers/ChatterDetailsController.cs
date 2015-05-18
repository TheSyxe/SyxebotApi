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
    public class ChatterDetailsController : ApiController
    {
        private SyxebotDatabaseModel db = new SyxebotDatabaseModel();

        // GET: api/ChatterDetails
        public IQueryable<ChatterDetail> GetChatterDetails()
        {
            return db.ChatterDetails;
        }

        // GET: api/ChatterDetails/<channelName>/<chatterName>
        [ResponseType(typeof(ChatterDetail))]
        public async Task<IHttpActionResult> GetChatterDetail(string channelName, string chatterName)
        {
            Channel channel = await db.Channels.FirstAsync(c => c.Name.ToLower() == channelName.ToLower());
            if (channel == null)
                return NotFound();
            List<Chatter> chatters = channel.Chatters.ToList();
            Chatter chatter = chatters.First(v => v.Name.ToLower() == chatterName.ToLower());
            if (chatter == null)
                return NotFound();
            var detail = chatter.ChatterDetail;

            return Ok(detail);
        }

        //// PUT: api/ChatterDetails/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutChatterDetail(int id, ChatterDetail chatterDetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != chatterDetail.ChatterId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(chatterDetail).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ChatterDetailExists(id))
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

        //// POST: api/ChatterDetails
        //[ResponseType(typeof(ChatterDetail))]
        //public async Task<IHttpActionResult> PostChatterDetail(ChatterDetail chatterDetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ChatterDetails.Add(chatterDetail);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ChatterDetailExists(chatterDetail.ChatterId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = chatterDetail.ChatterId }, chatterDetail);
        //}

        //// DELETE: api/ChatterDetails/5
        //[ResponseType(typeof(ChatterDetail))]
        //public async Task<IHttpActionResult> DeleteChatterDetail(int id)
        //{
        //    ChatterDetail chatterDetail = await db.ChatterDetails.FindAsync(id);
        //    if (chatterDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ChatterDetails.Remove(chatterDetail);
        //    await db.SaveChangesAsync();

        //    return Ok(chatterDetail);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatterDetailExists(int id)
        {
            return db.ChatterDetails.Count(e => e.ChatterId == id) > 0;
        }
    }
}