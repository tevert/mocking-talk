using System;
using Microsoft.AspNetCore.Mvc;
using Mocking.Services;

namespace Mocking.Controllers
{
    [Route("api/[controller]")]
    public class ActionController : Controller
    {
        private IEmailService emails;

        public ActionController(IEmailService emails)
        {
            this.emails = emails;
        }

        // POST api/actions
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var success = emails.SendEmail(value);
            if (!success)
            {
                throw new Exception("Email failure!");
            }
        }
    }
}
