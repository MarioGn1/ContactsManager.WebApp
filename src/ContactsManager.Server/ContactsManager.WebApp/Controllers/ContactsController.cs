using ContactsManager.Application.Commands;
using ContactsManager.Application.Commands.AddContact;
using ContactsManager.Application.Commands.DeleteContact;
using ContactsManager.Application.Commands.UpdateContact;
using ContactsManager.Application.Common;
using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces.Commands;
using ContactsManager.Application.Interfaces.Queries;
using ContactsManager.Application.Queries;
using ContactsManager.Application.Queries.GetAll;
using ContactsManager.Application.Queries.GetById;
using ContactsManager.Application.Queries.GetByName;
using ContactsManager.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManager.WebApp.Controllers
{
    [Authorize]
    public class ContactsController : ApiControler
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICommandDispatcher commandDispatcher;
        private readonly IQueryDispatcher queryDispatcher;

        public ContactsController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;

            commandDispatcher = new CommandDispatcher(this.httpContextAccessor.HttpContext.RequestServices);
            queryDispatcher = new QueryDispatcher(this.httpContextAccessor.HttpContext.RequestServices);
        }



        [HttpGet]
        public async Task<ActionResult<string>> GetAll()
        {
            var userId = GetUserId();
            var result = await queryDispatcher.Send(new GetAllQuery { OwnerId = userId});
            List<ContactDisplay> response = new List<ContactDisplay>();
            if (result != null && result.Count > 0)
                foreach (var member in result)
                {
                    response.Add((ContactDisplay)member);
                }
            return Ok(response);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult> GetByName(string name)
        {
            var userId = GetUserId();
            var result = await queryDispatcher.Send(new GetByNameQuery { OwnerId = userId, Name = name });
            List<ContactDisplay> response = new List<ContactDisplay>();
            if (result != null && result.Count > 0)
                foreach (var member in result)
                {
                    response.Add((ContactDisplay)member);
                }
            return Ok(response);
        }        

        [HttpGet]
        [Route("details/{id}")]
        public async Task<ActionResult> GetDetails(int id)
        {
            var userId = GetUserId();
            var result = await queryDispatcher.SendSingle(new GetByIdQuery { OwnerId = userId, ContactId = id });
            if (result == null)
            {
                return BadRequest("Contact not found.");
            }
            var response = (ContactDetailsDisplay)result;            
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateContact([FromBody]AddContactCommand command)
        {
            command.OwnerId = GetUserId();
            try
            {
                await commandDispatcher.Send(command);
            }
            catch (CommandException e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok("Successfully created.");
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateContact([FromBody]UpdateContactCommand command)
        {
            command.OwnerId = GetUserId();
            try
            {
                await commandDispatcher.Send(command);
            }
            catch (CommandException e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Successfully updated.");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            try
            {
                var userId = GetUserId();
                await commandDispatcher.Send(new DeleteContactCommand { OwnerId = userId, ContactId = id });
            }
            catch
            {
                return BadRequest();
            }
            
            return Ok("Successfully deleted");
        }

        private string GetUserId()
            => User.Identity.Name;
    }
}
