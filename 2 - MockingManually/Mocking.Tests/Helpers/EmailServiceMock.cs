using Mocking.Services;
using System.Collections.Generic;

namespace Mocking.Tests.Helpers
{
    public class EmailServiceMock : IEmailService
    {
        public List<string> Invocations { get; private set; } = new List<string>();

        public Dictionary<string, bool> Behaviors { get; private set; } = new Dictionary<string, bool>();

        public bool DefaultBehavior { get; set; } = false;

        public bool SendEmail(string message)
        {
            Invocations.Add(message);
            var hadSpecialValue = Behaviors.TryGetValue(message, out bool value);
            if (hadSpecialValue)
            {
                return value;
            }
            return DefaultBehavior;
        }
    }
}
