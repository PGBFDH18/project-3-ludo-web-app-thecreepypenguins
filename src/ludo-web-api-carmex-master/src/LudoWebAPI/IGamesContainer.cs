using System.Collections.Generic;
using LudoGameEngine;

namespace LudoWebAPI
{
    public interface IGamesContainer
    {
        List<int> GetAllGames();
        LudoGame GetOrCreateGame(int id);
        void DeleteGame(int id);

    }
}