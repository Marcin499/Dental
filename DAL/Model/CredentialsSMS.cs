using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    [Table("CredentialsSMS")]
   public class CredentialsSMS
    {
        public int ID { get; set; }

        public string AccountSid { get; set; }

        public string AuthToken { get; set; }
    }
}
