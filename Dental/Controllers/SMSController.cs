using System.Web.Mvc;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Dental.Controllers
{
    public class SMSController : TwilioController
    {
        // GET: SMS
        public ActionResult WyslijSMS()
        {
            const string accountSid = "ACa81779d44dd720e3911cb7e717818bd1";
            const string authToken = "33492b67c180493176a4e941f92d8f1c";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+48513760009");
            var from = new PhoneNumber("+12054311158");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Hello tu test");

            return Content(message.Sid);

        }
    }
}