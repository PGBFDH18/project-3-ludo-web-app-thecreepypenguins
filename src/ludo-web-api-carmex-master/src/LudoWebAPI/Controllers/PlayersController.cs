using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoGameEngine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LudoWebAPI.Controllers
{
    [Route("api/ludo")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private IGamesContainer _games;

        public PlayersController(IGamesContainer games)
        {
            _games = games;
        }
        // GET: api/ludo/{id}/players
        [HttpGet("{id}/players")]
        public JsonResult Get(int id)
        {
            // hämtar spelet där spelaren skall skapas
            LudoGame game = _games.GetOrCreateGame(id);

            // hämta alla spelare i spelet
            Player[] players = game.GetPlayers();

            // retunera all spelare i JSON format
            return new JsonResult(players);
        }

        // POST: api/ludo/{id}/players
        [HttpPost("{id}/players")]
        public JsonResult Post(int id, string name, int color)
        {

            // hämtar spelet där spelaren skall skapas
            LudoGame game = _games.GetOrCreateGame(id);

            // lägg till en ny spelare till spelet
            Player player = game.AddPlayer(name, (PlayerColor) color);

            // retunera den nya spelaren
            return new JsonResult(player);
        }       
    }
}
