using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Routing.Models.Entities
{
    public class LeagueModel
    {
        [Key]
        public int id { get; set; }
        public string caption { get; set; }
        public string league { get; set; }
        public int year { get; set; }
    }
}