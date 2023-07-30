using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class PhoneNumber
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PhoneId { get; set; }

        public double Number { get; set; }

        public int DeviceId { get; set; }

        public virtual Device device { get; set; }


    }
}