using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Routing.Models.Entities
{
    public class LinkLeagueModel : UrlBaseModel
    {
        public UrlBaseModel self { get; set; }
        public UrlBaseModel competition { get; set; }
    }
}