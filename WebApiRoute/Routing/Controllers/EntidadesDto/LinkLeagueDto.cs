using Routing.Controllers.EntidadesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Routing.Models.Entidades
{
    public class LinkLeagueDto : UrlBaseDto
    {
        public UrlBaseDto self { get; set; }
        public UrlBaseDto teams { get; set; }
        public UrlBaseDto fixtures { get; set; }
        public UrlBaseDto leagueTable { get; set; }
    }
}