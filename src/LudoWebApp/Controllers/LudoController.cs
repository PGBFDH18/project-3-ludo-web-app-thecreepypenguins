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

            SpecificGame result = GetSpeficifGameFromAPi();
            return View(result);
        }

        public SpecificGame GetSpeficifGameFromAPi()
        {
            var client = new RestClient("http://someserver.com/api LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!");
            var request = new RestRequest("ludo/{id}", Method.GET);
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            IRestResponse<SpecificGame> ludoGameResponse = client.Execute<SpecificGame>(request);
            return ludoGameResponse.Data;
        }

        public ExsistingGames GetGamesFromAPI()
        {
            var client = new RestClient("http://someserver.com/api LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!");
            var request = new RestRequest("ludo/", Method.GET);

            IRestResponse<ExsistingGames> ludoGameResponse = client.Execute<ExsistingGames>(request);

            return ludoGameResponse.Data;
        }

        // ludo/{gameId}
        // Detaljerat information om spelet, som vart alla pjäser finns. returnerar spelaranra och pjäserna som objekt
        public Player GetPiecePosition()
        {
            var client = new RestClient("http://someserver.com/api LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!");
            var request = new RestRequest("ludo/{gameID}", Method.GET); 

            IRestResponse<Player> piecesAndPlayer = client.Execute<Player>(request);

            return piecesAndPlayer.Data;
        }
    }




}
