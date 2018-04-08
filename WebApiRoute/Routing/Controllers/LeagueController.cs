using Routing.Controllers.EntidadesDto;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Routing.Models.Entities;
using Routing.Models;
using System.Linq;
using System.Collections.Generic;

namespace Routing.Controllers
{
    public class LeagueController : ApiController
    {
        [HttpGet]
        [Route("Import-League/{leagueCode}")]
        public async Task<LeagueDto> Team(string leagueCode)
        {

            LeagueModel leagueFinded;
            using (var db = new Contexto())
            {
                List<LeagueModel> entities = db.Leagues.ToList();
                leagueFinded = (from LeagueModel entity in entities where entity.league == leagueCode select entity).FirstOrDefault();
            }

            if (leagueFinded == null)
            {
                string urlExternal = string.Format("http://www.football-data.org/v1/competitions");
                var leagues = await GetAsync<List<LeagueDto>>(urlExternal);
                List<LeagueModel> importList = new List<LeagueModel>();
                foreach (LeagueDto dto in leagues)
                {
                    var model = Map(dto);
                    if (model != null) importList.Add(model);
                }

                if (importList.Any())
                {
                    using (var db = new Contexto())
                    {
                        db.Set<LeagueModel>().AddRange(importList);
                        db.SaveChanges();
                    }
                }
            }

            return Map(leagueFinded);
        }

        private static async Task<T> GetAsync<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                try
                {
                    T result = await content.ReadAsAsync<T>();
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private LeagueModel Map(LeagueDto dto)
        {
            if (dto == null) return null;
            LeagueModel model = new LeagueModel();
            model.caption = dto.caption;
            model.league = dto.league;
            model.year = dto.year;
            return model;
        }

        private LeagueDto Map(LeagueModel model)
        {
            if (model == null) return null;
            LeagueDto dto = new LeagueDto();
            dto.caption = model.caption;
            dto.league = model.league;
            dto.year = model.year;
            return dto;
        }
    }
}
