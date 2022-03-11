using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.WebApp.Controllers
{
    [Authorize]
    public class ContactsController : ApiControler
    {
        [HttpGet]
        [Route("all")]
        public ActionResult<string> GetAll()
        {
            return Ok("Thats cool at all!");
        }

        [HttpGet]
        [Route("nameSpecificContacts")]
        public ActionResult<string> GetByName(string name)
        {
            return "Thats specific cool!";
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<string> CreateContact(string name)
        {
            return "Thats create contact!";
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<string> UpdateContact(string name)
        {
            return "Thats update contact!";
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult<string> DeleteContact(string name)
        {
            this.SignIn(User);
            return "Thats delete contact!";
        }
    }
}
