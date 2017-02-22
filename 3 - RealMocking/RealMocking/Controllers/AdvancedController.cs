using RealMocking.Services;
using System.Web.Http;

namespace RealMocking.Controllers
{
    public class AdvancedController : ApiController
    {
        private IEmailService emails;
        private IMessageBuilder messages;

        public AdvancedController(IEmailService emails, IMessageBuilder messages)
        {
            this.emails = emails;
            this.messages = messages;
        }

        // POST api/actions
        public void Post([FromBody]string name)
        {
            var message = messages.Greeting(name);
            var success = emails.SendEmail(message);
            if (!success)
            {
                throw new System.Exception($"Error sending email: {message}");
            }
        }
    }
}
