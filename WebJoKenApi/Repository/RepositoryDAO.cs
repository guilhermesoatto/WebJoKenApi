using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJoKenApi.Model;
using WebJoKenApi.Repository.Context;

namespace WebJoKenApi.Repository
{
    public class IRepositoryDAO : IRepository
    {
        private readonly ContextDb contextDb;
        public IRepositoryDAO(ContextDb context)
        {
            contextDb = context;
        }

        public string AddPlayer(Player player)
        {
            contextDb.Add(player);
            contextDb.SaveChanges();

            return player.Name;
        }

        public List<Player> GetPlayers()
        {
            return contextDb.PlayerDB.ToList();
        }
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    contextDb.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void EndRound(Player winner)
        {
            var win = contextDb.PlayerDB.FirstOrDefault(x => x.Id == winner.Id);
            win.Points =+ 1;
            contextDb.PlayerDB.Update(win);
        }

        public Player Play(Guid id, string jogada)
        {
            var player = contextDb.PlayerDB.FirstOrDefault(x => x.Id == id);
            var computer = contextDb.PlayerDB.FirstOrDefault(x => x.Name.Contains("EuBOT"));

            int jogadaplayer = int.Parse(jogada);
            int jogadapc = new Random().Next(0, 2);
            if (jogadapc == jogadaplayer)
            {
                return computer;
            }
            switch (jogadaplayer)
            {
                case 0:
                    return jogadapc == 1 ? computer : player;
                case 1:
                    return jogadapc == 2 ? computer : player;
                default:
                    return jogadapc == 0 ? computer : player; ;
            }

        }
    }
}
