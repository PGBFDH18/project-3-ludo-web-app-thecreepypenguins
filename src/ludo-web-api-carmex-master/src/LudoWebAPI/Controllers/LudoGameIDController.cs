using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoGameEngine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LudoWebAPI.Controllers
{   // Kolla så routern är rätt här?
    [Route("api/ludo")]
    [ApiController]
    public class LudoGameIDController : ControllerBase
    {
        private IGamesContainer _games;

        public LudoGameIDController(IGamesContainer games)
        {
            _games = games;
        }

        // GET: api/ludo/{gameId}
        [HttpGet("{gameId}")]
        public JsonResult Get(int gameId)
        {
            LudoGame game = _games.GetOrCreateGame(gameId);

            return new JsonResult(new
            {
                gameId,
                currentPlayer = game.GetCurrentPlayer(),
                players = game.GetPlayers(),
                pieces = game.GetAllPiecesInGame()
            });
        }

        // PUT: api/ludo/{gameid}
        [HttpPut("{gameId}")]
        public JsonResult Put(int gameId)
        {
            LudoGame game = _games.GetOrCreateGame(gameId);

            if (game.GetGameState() == GameState.Ended)
            {
                // Retunera spelaren vann
                return new JsonResult(
                    new
                    {
                        winner = game.GetWinner()
                    });
            }

            // kontrollera att spelet har startat första gången någon flyttar en pjäs, annars starta spelet först
            if (game.GetGameState() == GameState.NotStarted)
            {
                game.StartGame();
            }

            // Hämta nuvarande spelare
            Player player = game.GetCurrentPlayer();

            // Kasta tärningen
            int diece = game.RollDiece();

            // hämta första pjäsen från spelaren som är på målsträckan
            Piece piece = player.Pieces.FirstOrDefault(m => m.State == PieceGameState.GoalPath);

            // om ingen pjäs är på målsträckan, ta en som är på spel planen istället
            if (piece == null)
            {
                piece = player.Pieces.FirstOrDefault(m => m.State == PieceGameState.InGame);
            }

            // om ingen pjäs är på spelplanen, ta en från boet
            if (piece == null)
            {
                piece = player.Pieces.FirstOrDefault(m => m.State == PieceGameState.HomeArea);
            }

            // vi har en pjäs som spelaren kan flytta
            if (piece != null)
            {
                game.MovePiece(player, piece.PieceId, diece);
            }

            // Avsluta spelarens tur, om hen slår sex, får de spela om
            if (diece != 6)
            {
                game.EndTurn(player);
            }
              
            // kontrollera om någon vunnit eller ej
            if (game.GetGameState() != GameState.Ended)
            {
                // Retunera spelaren som spelade, så man kan se pjäsen flyttat på sig
                return new JsonResult(
                    new
                    {
                        diece,
                        piece,
                        player
                    });
            }
            else
            {
                // Retunera spelaren vann
                return new JsonResult(
                    new
                    {
                        winner = game.GetWinner()
                    });
            }
        }

        // DELETE: api/ludo/{gameid}
        [HttpDelete("{gameId}")]
        public void Delete(int gameId)
        {
            _games.DeleteGame(gameId);
        }
    }
}
