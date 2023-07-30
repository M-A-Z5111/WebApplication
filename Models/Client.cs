using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication.Models.Enum;

namespace WebApplication.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public Classification Classification { get; set; }

        public DateTime Birthdate { get; set; }
    }
}