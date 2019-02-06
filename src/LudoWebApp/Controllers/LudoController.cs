using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoWebApp.LudoModels;
using Microsoft.AspNetCore.Mvc;
using RestSharp;



namespace LudoWebApp.Controllers
{
    public class LudoController : Controller
    {
        public IActionResult Index()
        {
            /* test för utskrift
            SpecificGame result = new SpecificGame()
            {
                currentPlayer = new Player()
                {
                    Name = "test"
                }
            };*/

            SpecificGamePlayers result = GetSpecificGamePlayers();
            return View(result);
        }

        public ExsistingGames GetGamesFromAPI()
        {
            var client = new RestClient("http://someserver.com/api LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!");
            var request = new RestRequest("ludo/", Method.GET);

            IRestResponse<ExsistingGames> ludoGameResponse = client.Execute<ExsistingGames>(request);

            return ludoGameResponse.Data;
        }
        
        public Player GetPiecesPosition()
        {
            var client = new RestClient("http://someserver.com/api");
            var request = new RestRequest("ludo/{gameID}", Method.GET);

            IRestResponse<Player> piecesAndPlayer = client.Execute<Player>(request);

            return piecesAndPlayer.Data;
            //kommer det att ta med piece och player?? eftersom player inte har pieces la in pieces i player
        }

        public SpecificGamePlayers GetSpecificGamePlayers()
        {
            var client = new RestClient("http://localhost:52858/");
            var request = new RestRequest("ludo/{id}/players", Method.GET);
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            IRestResponse<SpecificGamePlayers> ludoGameResponse = client.Execute<SpecificGamePlayers>(request);
            return ludoGameResponse.Data;
        }

        public Player GetSpecificPlayer()
        {
            var client = new RestClient("http://someserver.com/api");
            var request = new RestRequest("ludo/{id}/players/{playerId}", Method.GET);
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            IRestResponse<Player> playerResponse = client.Execute<Player>(request);
            return playerResponse.Data;
        }

        // KOLLA HUR MAN GÖR POST DELETE PUT REQUESTS MOT API:ET
    }




}
