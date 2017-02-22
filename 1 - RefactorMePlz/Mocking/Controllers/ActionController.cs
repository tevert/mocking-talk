using System;
using Microsoft.AspNetCore.Mvc;
using Mocking.Utils;

namespace Mocking.Controllers
{
    [Route("api/[controller]")]
    public class ActionController : Controller
    {
        // POST api/actions
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var success = EmailUtils.SendEmail(value);
            if (!success)
            {
                throw new Exception("Email failure!");
            }
        }
    }
}