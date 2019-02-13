using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoWebApp.LudoModels;
using LudoWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;



namespace LudoWebApp.Controllers
{
    public class LudoController : Controller
    {
        //så att man kan använda logger i index metoden eller andra action i denna klassen
        private readonly ILogger logger;

        //konstruktor, loggar sätts vid hjälp av dependency injection
        public LudoController(ILogger<LudoController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            logger.LogInformation(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> get all games");

            /* test för utskrift
            SpecificGame result = new SpecificGame()
            {
                currentPlayer = new Player()
                {
                    Name = "test"
                }
            };*/

            //TEsta get metoderna med hjälp av postman, man måste först skapa spelet med hjälå av postman. och lägga till spelare

            //var allGames = GetGamesFromAPI(); // ta fram alla spel
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


            //en klass som skicka in i view 
            return View(viewModel);
        }

        public IActionResult RollDice(int gameId)
        {
            var viewModel = new LudoViewModel();

            var r = new Random();
            viewModel.Dice = r.Next(6) + 1;

            // Testa att kasta en tärning, tärningen skall egentligen komma från REST API projektet
            //var r = new Random();
            //result.dice = r.Next(6) + 1;

            //"Index" för att få samma utseende som index metoden
            return View("Index", viewModel);
        }

        public IActionResult CreateNewGame(LudoViewModel viewModel)
        {
            //var client = new RestClient("http://someserver.com/api");

            //var request = new RestRequest("ludo/", Method.POST);
            //request.AddJsonBody();//lägg till det som är i creategae så man kan skapa spel

            List<Player> players = new List<Player>();

            if (viewModel.ColorPlayer1 != "-1")
            {
                players.Add(new Player() { PlayerColor = viewModel.ColorPlayer1 });
            }
            if (viewModel.ColorPlayer2 != "-1")
            {
                players.Add(new Player() { PlayerColor = viewModel.ColorPlayer2 });
            }
            if (viewModel.ColorPlayer3 != "-1")
            {
                players.Add(new Player() { PlayerColor = viewModel.ColorPlayer3 });
            }
            if (viewModel.ColorPlayer4 != "-1")
            {
                players.Add(new Player() { PlayerColor = viewModel.ColorPlayer4 });
            }

            if (players.Count() < 2)
            {
                ModelState.AddModelError("Player1", "Minimum 2 players");
            }

            // Om inga fel uppstod skapa spelet
            if (ModelState.IsValid)
            {
                //skapa spelet i api
                int gameId = CreateGameUsingApi();

                //lägg till spelare
                foreach (var player in players)
                {
                    AddPlayerToGame(gameId, player.PlayerColor);
                }

                //hämtar spelet ifrån api
                viewModel.CurrentGame = GetSpeficifGameFromAPi(gameId);
                
            }

            //"Index" för att få samma utseende som index metoden
            return View("Index", viewModel);
        }

        //med hjälp av API så skapas spelet
        public int CreateGameUsingApi()
        {
            var client = new RestClient("http://localhost:52858/api"); //LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!
            var request = new RestRequest("ludo/", Method.POST);

            IRestResponse<int> ludoGameResponse = client.Execute<int>(request);

            // Om det blir fel svar från API:et så kasta ett fel istället för att gå vidare
            if (ludoGameResponse.ErrorException != null)
                throw ludoGameResponse.ErrorException;

            return ludoGameResponse.Data;
        }

        public Game GetSpeficifGameFromAPi(int gameId)
        {
            var client = new RestClient("http://localhost:52858/api"); //LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!
            var request = new RestRequest("ludo/{gameId}", Method.GET);
            request.AddUrlSegment("gameId", gameId); // replaces matching token in request.Resource

            IRestResponse<Game> ludoGameResponse = client.Execute<Game>(request);

            // Om det blir fel svar från API:et så kasta ett fel istället för att gå vidare
            if (ludoGameResponse.ErrorException != null)
                throw ludoGameResponse.ErrorException;

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
            var client = new RestClient("http://localhost:52858/api");
            var request = new RestRequest("ludo/{gameId}/players", Method.GET);
            request.AddUrlSegment("gameId", gameId); // replaces matching token in request.Resource

            IRestResponse<List<Player>> ludoGameResponse = client.Execute<List<Player>>(request);

            // Om det blir fel svar från API:et så kasta ett fel istället för att gå vidare
            if (ludoGameResponse.ErrorException != null)
                throw ludoGameResponse.ErrorException;

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

        public Player AddPlayerToGame(int gameId, string playerColor)
        {
            var client = new RestClient("http://localhost:52858/api"); //LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!
            var request = new RestRequest("ludo/{gameId}/players", Method.POST);
            request.AddUrlSegment("gameId", gameId); // replaces matching token in request.Resource
            request.AddQueryParameter("color", playerColor);
            request.AddQueryParameter("name", "Player " + playerColor);

            IRestResponse<Player> ludoGameResponse = client.Execute<Player>(request);

            // Om det blir fel svar från API:et så kasta ett fel istället för att gå vidare
            if (ludoGameResponse.ErrorException != null)
                throw ludoGameResponse.ErrorException;

            return ludoGameResponse.Data;
        }
        //public void UpdatePices() //updatera en pjäs
        //{
        //    var client = new RestClient("http://someserver.com/api");

        //    var request = new RestRequest("ludo/{gameId}/players/{playerId}", Method.POST);


        //    // request.AddJsonBody(); 
        //}
    }




}
