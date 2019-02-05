﻿using System;
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

            SpecificGame result = GetSpeficifGameFromAPi(123);

            return View(result);
        }

        public IActionResult RollDice(int gameId)
        {
            SpecificGame result = GetSpeficifGameFromAPi(gameId);

            // Testa att kasta en tärning, tärningen skall egentligen komma från REST API projektet
            var r = new Random();
            result.dice = r.Next(6) + 1;

            //"Index" för att få samma utseende som index metoden
            return View("Index", result);
        }

        public SpecificGame GetSpeficifGameFromAPi(int gameId)
        {
            var client = new RestClient("http://localhost:52858/api"); //LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!
            var request = new RestRequest("ludo/{id}", Method.GET);
            request.AddUrlSegment("id", gameId); // replaces matching token in request.Resource

            IRestResponse<SpecificGame> ludoGameResponse = client.Execute<SpecificGame>(request);
            return ludoGameResponse.Data;
        }

        public ExsistingGames GetGamesFromAPI()
        {
            var client = new RestClient("http://localhost:52858/api"); // LOCALHOST PÅ VÅRT API NÄR VI STARTAT UPP DET!!!
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
