using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJoKenApi.Model;

namespace WebJoKenApi.Repository
{
    public interface IRepository : IDisposable
    {
        string AddPlayer(Player player);
        List<Player> GetPlayers();
        void EndRound(Player winner);
        Player Play(Guid player, string jogada);
    }
}
