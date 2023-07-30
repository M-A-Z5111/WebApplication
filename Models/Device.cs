using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using WebApplication.DataBase;

namespace WebApplication.Models
{
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int DeviceId { get; set; }

        public string DeviceName { get; set; }

        public virtual ICollection<PhoneNumber> phonenumbers { get; set; }

       

    }
}
