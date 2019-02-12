using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoWebApp.LudoModels;
using LudoWebApp.Models;
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

            //TEsta get metoderna med hjälp av postman, man måste först skapa spelet med hjälå av postman. och lägga till spelare

            var allGames = GetGamesFromAPI(); // ta fram alla spel
            //var player = GetSpecificPlayer(0, 0); // ta fram en spelare ifrån ett spel
            //var playersInGame = GetSpecificGamePlayers(0); // ta fram alla spelare i ett spel
            //var game = GetSpeficifGameFromAPi(0); //hämta ett spel och få alla detaljer om det

            //skapar en viewModel
            var viewModel = new LudoViewModel();

            //få alla spel som ett objekt och inte int
            IEnumerable<int> allGameIds = GetGamesFromAPI();

            //skapa en tom lista för alla spel 
            viewModel.AllGames = new List<Game>();

            //hämtar alla spel ifrån API
            foreach (var gameId in allGameIds)
            {
                viewModel.AllGames.Add(GetSpeficifGameFromAPi(gameId));
            }

            viewModel.Dice = 4;

            //en klass som skicka in i view 
            return View(viewModel);
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

        public Game GetSpeficifGameFromAPi(int gameId)
        {
<<<<<<< HEAD
            var client = new RestClient("http://localhost:52858/api/"); //LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!
            var request = new RestRequest("ludo/{id}", Method.GET);
           // request.AddUrlSegment("id", gameId); // replaces matching token in request.Resource
=======
            var client = new RestClient("http://localhost:52858/api"); //LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!
            var request = new RestRequest("ludo/{gameId}", Method.GET);
            request.AddUrlSegment("gameId", gameId); // replaces matching token in request.Resource

            IRestResponse<Game> ludoGameResponse = client.Execute<Game>(request);

            // Om det blir fel svar från API:et så kasta ett fel istället för att gå vidare
            if (ludoGameResponse.ErrorException != null)
                throw ludoGameResponse.ErrorException;
>>>>>>> 8caf0efe43791090d6a1dc79801d87e514b65bea

            return ludoGameResponse.Data;
        }

        public IEnumerable<int> GetGamesFromAPI()
        {
            var client = new RestClient("http://localhost:52858/api"); // LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!
            var request = new RestRequest("ludo/", Method.GET);

            IRestResponse<List<int>> ludoGameResponse = client.Execute<List<int>>(request);

            // Om det blir fel svar från API:et så kasta ett fel istället för att gå vidare
            if (ludoGameResponse.ErrorException != null)
                throw ludoGameResponse.ErrorException;

            return ludoGameResponse.Data;
        }

        public Player GetPiecesPosition()
        {
            var client = new RestClient("http://someserver.com/api");
            var request = new RestRequest("ludo/{gameID}", Method.GET);

            IRestResponse<Player> piecesAndPlayer = client.Execute<Player>(request);

            // Om det blir fel svar från API:et så kasta ett fel istället för att gå vidare
            if (piecesAndPlayer.ErrorException != null)
                throw piecesAndPlayer.ErrorException;

            return piecesAndPlayer.Data;
        }

        public List<Player> GetSpecificGamePlayers(int gameId)
        {
<<<<<<< HEAD
            var client = new RestClient("http://someserver.com/api");
            var request = new RestRequest("ludo/{id}/players", Method.GET);
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
=======
            var client = new RestClient("http://localhost:52858/api");
            var request = new RestRequest("ludo/{gameId}/players", Method.GET);
            request.AddUrlSegment("gameId", gameId); // replaces matching token in request.Resource

            IRestResponse<List<Player>> ludoGameResponse = client.Execute<List<Player>>(request);

            // Om det blir fel svar från API:et så kasta ett fel istället för att gå vidare
            if (ludoGameResponse.ErrorException != null)
                throw ludoGameResponse.ErrorException;
>>>>>>> 8caf0efe43791090d6a1dc79801d87e514b65bea

            return ludoGameResponse.Data;
        }

        public Player GetSpecificPlayer(int gameId, int playerId)
        {
            var client = new RestClient("http://localhost:52858/api");
            var request = new RestRequest("ludo/{gameId}/players/{playerId}", Method.GET);
            request.AddUrlSegment("gameId", gameId); // replaces matching token in request.Resource
            request.AddUrlSegment("playerId", playerId); // replaces matching token in request.Resource

            IRestResponse<Player> playerResponse = client.Execute<Player>(request);

            // Om det blir fel svar från API:et så kasta ett fel istället för att gå vidare
            if (playerResponse.ErrorException != null)
                throw playerResponse.ErrorException;

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
