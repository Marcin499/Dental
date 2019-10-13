using DAL;
using DAL.Model;
using System;
using System.Linq;
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
        public ActionResult WyslijSMSPotwierdzenie(string data, string godzina, int numer)
        {
            Metody client = new Metody();
            var dane = client.GetCredentialSMSList().Last();
            string accountSid = dane.AccountSid;
            string authToken = dane.AuthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+48" + numer.ToString());
            var from = new PhoneNumber("+12054311158");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Potwierdzenie dokonania rejestracji wizyty w dniu: " + data + " o godzinie: " + godzina + ". Pozdrawiamy zespół Dental. ");

            return Content(message.Sid);
        }

        public ActionResult WyslijSMSPrzypomnienie(Wizyta parametr)
        {
            Metody client = new Metody();
            var pacjent = client.GetPacjentByID(parametr.PacjentID);
            var dane = client.GetCredentialSMSList().Last();
            string accountSid = dane.AccountSid;
            string authToken = dane.AuthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+48" + pacjent.Telefon.ToString());
            var from = new PhoneNumber("+12054311158");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Przypominamy o jutrzejszej wizycie w dniu: " + DateTime.Now.AddDays(1).ToShortDateString() + " o godzinie: " + parametr.Godzina + ". Pozdrawiamy zespół Dental. ");

            return Content(message.Sid);
        }
    }
}