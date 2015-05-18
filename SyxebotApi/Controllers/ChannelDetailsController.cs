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
    public class ChannelDetailsController : ApiController
    {
        private SyxebotDatabaseModel db = new SyxebotDatabaseModel();

        // GET: api/ChannelDetails
        //public IQueryable<ChannelDetail> GetChannelDetails()
        //{
        //    return db.ChannelDetails;
        //}

        // GET: api/ChannelDetails/<channelName>
        [ResponseType(typeof(ChannelDetail))]
        public async Task<IHttpActionResult> GetChannelDetail(string channelName)
        {
            Channel channel = await db.Channels.FirstAsync(c => c.Name.ToLower() == channelName.ToLower());
            if (channel == null)
                return NotFound();

            ChannelDetail channelDetail = channel.ChannelDetail;
            if (channelDetail == null)
                return NotFound();
            return Ok(channelDetail);
        }

        //// PUT: api/ChannelDetails/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutChannelDetail(int id, ChannelDetail channelDetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != channelDetail.ChannelId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(channelDetail).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ChannelDetailExists(id))
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

        //// POST: api/ChannelDetails
        //[ResponseType(typeof(ChannelDetail))]
        //public async Task<IHttpActionResult> PostChannelDetail(ChannelDetail channelDetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ChannelDetails.Add(channelDetail);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ChannelDetailExists(channelDetail.ChannelId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = channelDetail.ChannelId }, channelDetail);
        //}

        //// DELETE: api/ChannelDetails/5
        //[ResponseType(typeof(ChannelDetail))]
        //public async Task<IHttpActionResult> DeleteChannelDetail(int id)
        //{
        //    ChannelDetail channelDetail = await db.ChannelDetails.FindAsync(id);
        //    if (channelDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ChannelDetails.Remove(channelDetail);
        //    await db.SaveChangesAsync();

        //    return Ok(channelDetail);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChannelDetailExists(int id)
        {
            return db.ChannelDetails.Count(e => e.ChannelId == id) > 0;
        }
    }
}