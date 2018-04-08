using Routing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Routing.Models
{
    public class Contexto : DbContext
    {
        public DbSet<LeagueModel> Leagues { get; set; }
    }
}