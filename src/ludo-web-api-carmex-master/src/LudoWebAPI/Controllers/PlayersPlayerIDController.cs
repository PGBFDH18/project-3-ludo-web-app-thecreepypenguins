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
    public class PlayersPlayerIDController : ControllerBase
    {
        private IGamesContainer _games;

        public PlayersPlayerIDController(IGamesContainer games)
        {
            _games = games;
        }

        // GET: api/ludo/3/players/1
        [HttpGet("{gameId}/players/{playerid}")]
        public JsonResult Get(int gameId, int playerId)
        {
            LudoGame game = _games.GetOrCreateGame(gameId);
           
            //tar ut den spelaren som har just detta id, player blir då ett objekt
            Player player = game.GetPlayers().Single(m => m.PlayerId == playerId);

            //gö om detta till en JSON
            return new JsonResult(player);
        }


        // PUT: api/ludo/3/players/1
        [HttpPut("{gameId}/players/{playerid}")]
        public JsonResult Put(int gameId, int playerId, int color, string name)
        {
            //hämtat ett spel som har de Id
            LudoGame game = _games.GetOrCreateGame(gameId);

            //tar ut den spelaren som har just detta id, player blir då ett objekt
            Player player = game.GetPlayers().Single(m => m.PlayerId == playerId);

            player.PlayerColor = (PlayerColor)color;

            player.Name = name;

            return new JsonResult(player);
        }

        // DELETE: api/ludo/gameId/players/{playerId}
        [HttpDelete("{gameId}/players/{playerid}")]
        public JsonResult Delete(int gameId, int playerId)
        {
            LudoGame game = _games.GetOrCreateGame(gameId);

            //tar ut den spelaren som har just detta id
            Player player = game.GetPlayers().Single(m => m.PlayerId == playerId);

            game.DeletePlayer(player);

            return new JsonResult(game.GetPlayers());
        }
    }
}
