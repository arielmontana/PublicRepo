using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Routing.Controllers
{
    public class LeagueController : ApiController
    {
        [HttpGet]
        [Route("Import-League/{leagueCode}")]
        public string Team(string leagueCode)
        {
            return string.Format("El código de League que se recibió fue: '{0}'", leagueCode);
        }
    }
}
