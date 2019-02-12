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
            var x = GetGamesFromAPI();

            SpecificGamePlayers result = GetSpeficifGameFromAPi();

            return View(result);
        }

        //public IActionResult RollDice(int gameId)
        //{
        //    SpecificGamePlayers result = GetSpeficifGameFromAPi(gameId);

        //    // Testa att kasta en tärning, tärningen skall egentligen komma från REST API projektet
        //    var r = new Random();
        //    result.dice = r.Next(6) + 1;

        //    //"Index" för att få samma utseende som index metoden
        //    return View("Index", result);
        //}

        public SpecificGamePlayers GetSpeficifGameFromAPi()
        {
            var client = new RestClient("http://localhost:52858/api/"); //LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!
            var request = new RestRequest("ludo/{id}", Method.GET);
           // request.AddUrlSegment("id", gameId); // replaces matching token in request.Resource

            IRestResponse<SpecificGamePlayers> ludoGameResponse = client.Execute<SpecificGamePlayers>(request);
            return ludoGameResponse.Data;
        }

        public IEnumerable<int> GetGamesFromAPI()
        {
            var client = new RestClient("http://someserver.com/api"); // LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!
            var request = new RestRequest("ludo/", Method.GET);

            IRestResponse<List<int>> ludoGameResponse = client.Execute<List<int>>(request);

            return ludoGameResponse.Data;
        }
        
        public Player GetPiecesPosition()
        {
            var client = new RestClient("http://someserver.com/api");
            var request = new RestRequest("ludo/{gameID}", Method.GET);

            IRestResponse<Player> piecesAndPlayer = client.Execute<Player>(request);

            return piecesAndPlayer.Data;
        }

        public SpecificGamePlayers GetSpecificGamePlayers()
        {
            var client = new RestClient("http://someserver.com/api");
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

        public void CreateNewGame()
        {
            var client = new RestClient("http://someserver.com/api");

            var request = new RestRequest("ludo/", Method.POST);
            request.AddJsonBody();//lägg till det som är i creategae så man kan skapa spel


        }
    }




}
