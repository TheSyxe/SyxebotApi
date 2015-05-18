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
    public class CommandsController : ApiController
    {
        private SyxebotDatabaseModel db = new SyxebotDatabaseModel();

        // GET: api/Commands
        //public IQueryable<Command> GetCommands()
        //{
        //    return db.Commands;
        //}

        // GET: api/Commands/<channelName>
        [ResponseType(typeof(List<Command>))]
        public async Task<IHttpActionResult> GetCommands(string channelName)
        {
            Channel channel = await db.Channels.FirstAsync(c => c.Name.ToLower() == channelName.ToLower());
            if (channel == null)
                return NotFound();
            List<Command> commands = channel.Commands.ToList();

            return Ok(commands);
        }
        // GET: api/Commands/<channelName>/<commandTrigger>
        [ResponseType(typeof(Command))]
        public async Task<IHttpActionResult> GetCommands(string channelName, string trigger)
        {
            Channel channel = await db.Channels.FirstAsync(c => c.Name.ToLower() == channelName.ToLower());
            if (channel == null)
                return NotFound();
            List<Command> commands = channel.Commands.ToList();
            var command = commands.First(t => t.Trigger.ToLower().Contains(trigger.ToLower()));
            if (command == null)
                return NotFound();
            return Ok(command);
        }
        //// PUT: api/Commands/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutCommand(int id, Command command)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != command.CommandId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(command).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CommandExists(id))
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

        //// POST: api/Commands
        //[ResponseType(typeof(Command))]
        //public async Task<IHttpActionResult> PostCommand(Command command)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Commands.Add(command);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = command.CommandId }, command);
        //}

        //// DELETE: api/Commands/5
        //[ResponseType(typeof(Command))]
        //public async Task<IHttpActionResult> DeleteCommand(int id)
        //{
        //    Command command = await db.Commands.FindAsync(id);
        //    if (command == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Commands.Remove(command);
        //    await db.SaveChangesAsync();

        //    return Ok(command);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommandExists(int id)
        {
            return db.Commands.Count(e => e.CommandId == id) > 0;
        }
    }
}