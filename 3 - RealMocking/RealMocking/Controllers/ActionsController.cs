using RealMocking.Services;
using System.Web.Http;

namespace RealMocking.Controllers
{
    public class ActionsController : ApiController
    {
        private IEmailService emails;
        public ActionsController(IEmailService emails)
        {
            this.emails = emails;
        }

        // POST api/actions
        public void Post([FromBody]string value)
        {
            var success = emails.SendEmail(value);
            if (!success)
            {
                throw new System.Exception($"Error sending email: {value}");
            }
        }
    }
}
